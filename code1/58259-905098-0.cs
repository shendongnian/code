    public class DBHelper
    {
        #region Private Variables
        private static string sourceSQLServer;
        private static string destinationSQLServer;
        private static string sourceDatabase;
        private static string destinationDatabase;
        #endregion 
        #region Properties
        /// <summary>
        /// SourceSQLServer Holds Instance Name of Source SQL Server Database Name
        /// </summary>
        public static string SourceSQLServer
        {
            get { return DBHelper.sourceSQLServer; }
            set { DBHelper.sourceSQLServer = value; }
        }
        /// <summary>
        /// DestinationSQLServer Holds Instance Name of Destination SQL Server Database Name
        /// </summary>
        public static string DestinationSQLServer
        {
            get { return DBHelper.destinationSQLServer; }
            set { DBHelper.destinationSQLServer = value; }
        }
        /// <summary>
        /// SourceDatabase Holds Source Database 
        /// </summary>
        public static string SourceDatabase
        {
            get { return DBHelper.sourceDatabase; }
            set { DBHelper.sourceDatabase = value; }
        }
        /// <summary>
        /// DestinationDatabase Holds Destination Database Name
        /// </summary>
        public static string DestinationDatabase
        {
            get { return DBHelper.destinationDatabase; }
            set { DBHelper.destinationDatabase = value; }
        }
        #endregion 
        #region Static Methods
        /// <summary>
        ///  CopyDatabase Copies Database 
        /// </summary>
        /// <param name="CopyData">True if Want to Copy Data otherwise False</param>
        public static void CopyDatabase(bool bCopyData)
        {
            //Set Source SQL Server Instance Information
            Server server = new Server(DBHelper.SourceSQLServer); 
            //Set Source Database Name [Database to Copy]
            Database database = server.Databases[DBHelper.SourceDatabase];            
            
            //Set Transfer Class Source Database
            Transfer transfer = new Transfer(database);
            
            //Yes I want to Copy All the Database Objects
            transfer.CopyAllObjects = true;
            
            //In case if the Destination Database / Objects Exists Drop them First
            transfer.DropDestinationObjectsFirst = true;
            //Copy Database Schema
            transfer.CopySchema = true;
            //Copy Database Data Get Value from bCopyData Parameter
            transfer.CopyData = bCopyData;
            //Set Destination SQL Server Instance Name
            transfer.DestinationServer = DBHelper.DestinationSQLServer;
            //Create The Database in Destination Server
            transfer.CreateTargetDatabase = true;      
            
            //Set Destination Database Name
            Database ddatabase = new Database(server, DBHelper.DestinationDatabase);
            //Create Empty Database at Destination
            ddatabase.Create();
            //Set Destination Database Name
            transfer.DestinationDatabase = DBHelper.DestinationDatabase;
            
            //Include If Not Exists Clause in the Script
            transfer.Options.IncludeIfNotExists = true; 
           
            //Start Transfer
            transfer.TransferData();
            //Release Server variable
            server = null;
        }
        #endregion 
    }
