    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using Rule=System.Data.Rule;
    
    namespace XSD2SQL
    {
    public class XSD2SQL
    {
        private readonly Server _server;
        private readonly SqlConnection _connection;
        private Database _db;
        private DataSet _source;
        private string _databaseName;
    
        public XSD2SQL(string connectionString, DataSet source)
        {
            _connection = new SqlConnection(connectionString);
            _server = new Server(new ServerConnection(_connection));
            _source = source;
        }
    
        public void CreateDatabase(string databaseName)
        {
            _databaseName = databaseName;
            _db = _server.Databases[databaseName];
            if (_db != null) _db.Drop();
            _db = new Database(_server, _databaseName);
            _db.Create();
        }
    
        public void PopulateDatabase()
        {
            CreateTables(_source.Tables);
            CreateRelationships();
        }
    
        private void CreateRelationships()
        {
            foreach (DataTable table in _source.Tables)
            {
                foreach (DataRelation rel in table.ChildRelations)
                    CreateRelation(rel);
            }
        }
    
        private void CreateRelation(DataRelation relation)
        {
            Table primaryTable = _db.Tables[relation.ParentTable.TableName];
            Table childTable = _db.Tables[relation.ChildTable.TableName];
    
            ForeignKey fkey = new ForeignKey(childTable, relation.RelationName);
            fkey.ReferencedTable = primaryTable.Name;
    
            fkey.DeleteAction = SQLActionTypeToSMO(relation.ChildKeyConstraint.DeleteRule);
            fkey.UpdateAction = SQLActionTypeToSMO(relation.ChildKeyConstraint.UpdateRule);
            
                        
            for (int i = 0; i < relation.ChildColumns.Length; i++)
            {
                DataColumn col = relation.ChildColumns[i];
                ForeignKeyColumn fkc = new ForeignKeyColumn(fkey, col.ColumnName, relation.ParentColumns[i].ColumnName);
    
                fkey.Columns.Add(fkc);
            }
    
            fkey.Create();
    
        }
    
        private void CreateTables(DataTableCollection tables)
        {
            foreach (DataTable table in tables)
            {                
                DropExistingTable(table.TableName);
                Table newTable = new Table(_db, table.TableName);
                
                PopulateTable(ref newTable, table);                
                SetPrimaryKeys(ref newTable, table);
                newTable.Create();
                
            }
        }
    
        private void PopulateTable(ref Table outputTable, DataTable inputTable)
        {
            foreach (DataColumn column in inputTable.Columns)
            {
                CreateColumns(ref outputTable, column, inputTable);
            }
        }
    
        private void CreateColumns(ref Table outputTable, DataColumn inputColumn, DataTable inputTable)
        {
            Column newColumn = new Column(outputTable, inputColumn.ColumnName);
            newColumn.DataType = CLRTypeToSQLType(inputColumn.DataType);
            newColumn.Identity = inputColumn.AutoIncrement;
            newColumn.IdentityIncrement = inputColumn.AutoIncrementStep;
            newColumn.IdentitySeed = inputColumn.AutoIncrementSeed;
            newColumn.Nullable = inputColumn.AllowDBNull;
            newColumn.UserData = inputColumn.DefaultValue;
            
            outputTable.Columns.Add(newColumn);
        }
    
        private void SetPrimaryKeys(ref Table outputTable, DataTable inputTable)
        {
            Index newIndex = new Index(outputTable, "PK_" + outputTable.Name);
            newIndex.IndexKeyType = IndexKeyType.DriPrimaryKey;
            newIndex.IsClustered = false;
    
            foreach (DataColumn keyColumn in inputTable.PrimaryKey)
            {                                
                newIndex.IndexedColumns.Add(new IndexedColumn(newIndex, keyColumn.ColumnName, true));                
            }
            if (newIndex.IndexedColumns.Count > 0)
                outputTable.Indexes.Add(newIndex);
        }
    
        
    
        private DataType CLRTypeToSQLType(Type type)
        {
            switch (type.Name)
            {
                case "String":
                    return DataType.NVarCharMax;
    
                case "Int32":
                    return DataType.Int;
    
                case "Boolean":
                    return DataType.Bit;
    
                case "DateTime":
                    return DataType.DateTime;
    
                case "Byte[]":
                    return DataType.VarBinaryMax;
    
    
            }
    
            return DataType.NVarCharMax;
        }
    
        private ForeignKeyAction SQLActionTypeToSMO(Rule rule)
        {
            string ruleStr = rule.ToString();
    
            return (ForeignKeyAction)Enum.Parse(typeof (ForeignKeyAction), ruleStr);
        }
    
        private void DropExistingTable(string tableName)
        {
            Table table = _db.Tables[tableName];
            if (table != null) table.Drop();
        }
    
    }
    }
