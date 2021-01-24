        using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Data.General
    {
        public abstract class DataObject
        {
            protected abstract void Initialize(IDataRecord dataRow);
            private static string _connectionString = "";
            /// <summary>
            /// Loads a single data object from the results of a stored procedure.
            /// </summary>
            protected static T ReadObject<T>(string procedureName, SqlParameter[] sqlParameters, Type dataType)
            {
                DataObject returnItem = null;
                using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = BuildCommand(sqlConnection, procedureName, sqlParameters))
                    {
                        //Execute the reader for the given stored proc and sql parameters
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            //If we get no records back we'll still return null
                            while (reader.Read())
                            {
                                returnItem = (DataObject)Activator.CreateInstance(typeof(T));
                                returnItem.Initialize(reader);
                                break;
                            }
                        }
                    }
                }
                //Return our DataObject
                return (T)Convert.ChangeType(returnItem, dataType);
            }
            /// <summary>
            /// Reads a collection of data objects from a stored procedure.
            /// </summary>
            protected static List<T> ReadObjects<T>(string procedureName, SqlParameter[] sqlParameters)
            {
                //Get cached data if it exists
                List<T> returnItems = new List<T>();
                T dataObject;
                using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = BuildCommand(sqlConnection, procedureName, sqlParameters, null))
                    {
                        //Execute the reader for the given stored proc and sql parameters
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            //If we get no records back we'll still return null
                            while (reader.Read())
                            {
                                dataObject = (T)Activator.CreateInstance(typeof(T));
                                (dataObject as DataObject).Initialize(reader);
                                returnItems.Add(dataObject);
                            }
                        }
                    }
                }
                //Return the DataObjects
                return returnItems;
            }
            /// <summary>
            /// Builds a SQL Command object that can be used to execute the given stored procedure.
            /// </summary>
            private static SqlCommand BuildCommand(SqlConnection sqlConnection, string procedureName, SqlParameter[] sqlParameters, SqlTransaction sqlTransaction = null)
            {
                SqlParameter param;
                SqlCommand cmd = new SqlCommand(procedureName, sqlConnection);
                if (sqlTransaction != null)
                {
                    cmd.Transaction = sqlTransaction;
                }
                cmd.CommandType = CommandType.StoredProcedure;
                // Add SQL Parameters (if any)
                foreach (SqlParameter parameter in sqlParameters)
                {
                    param = new SqlParameter(parameter.ParameterName, parameter.DbType);
                    param.Value = parameter.Value;
                    cmd.Parameters.Add(param);
                }
                return cmd;
            }
            private static string GetConnectionString()
            {
                return _connectionString;
            }
            public static void SetConnectionString(string connectionString)
            {
                _connectionString = connectionString;
            }
        }
    }
    namespace Data.Library
    {
        public class Metadata : General.DataObject
        {
            protected Data.Model.Metadata _metaData;
            public Data.Model.Metadata BaseModel
            {
                get { return _metaData; }
                set { _metaData = value; }
            }
            //Typically I have properties in here pointing to the Data.Model class
            protected override void Initialize(System.Data.IDataRecord dataRow)
            {
                _metaData = new Model.Metadata();
                _metaData.Id = Convert.ToInt32(dataRow["Id"].ToString());
                _metaData.Title = (dataRow["Title"].ToString());
                _metaData.Sku = (dataRow["Sku"].ToString());
                _metaData.IsLive = Convert.ToBoolean(dataRow["IsLive"].ToString());
            }
            public static Metadata ReadByID(int id)
            {
                return General.DataObject.ReadObject<Metadata>("dbo.s_MetadataGet", new[] { new SqlParameter("@ID", id) }, 
				    typeof(Metadata));
            }
            public static Metadata[] ReadBySku(string sku)
            {
                List<Metadata> metaDatas = General.DataObject.ReadObjects<Metadata>("dbo.s_MetadataGetBySku", new[] { new SqlParameter("@Sku", sku) });
                return metaDatas.ToArray();
            }
        }
    }
    namespace Data.Model
    {
        public class Metadata
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Sku { get; set; }
            public bool IsLive { get; set; }
        }
    }
