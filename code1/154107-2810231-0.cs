    OdbcDbConnection entityConnection = new OdbcDbConnection(entitiesConnectionString); 
    Entities db = new Entities(entityConnection); 
     DbCommand command = db.Connection.CreateCommand(); 
    command.CommandText ="CREATE TABLE MyTable (Id int NOT NULL, OtherTable_Id nchar(40)         REFERENCES OtherTable (Id) On Delete CASCADE On Update NO ACTION, SomeData nvarchar(1024) NOT NULL, Primary Key(Id) );"; 
    command.ExecuteNonQuery(); 
