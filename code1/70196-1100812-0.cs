     class CustomReaderClass : IDataReader
     {
        // make sure to implement the IDataReader inferface in this class
        // and a method to load the 61 000 data objects
        void Load()
        { 
           // do whatever you have to do here to load the data..
           //  maybe from a file..?!
        }
     }
     
     SQLBulkCopy  bulkCopyInstance;
     CustomReaderClass aCustomReaderClass = new aCustomReaderClass();
     aCustomReaderClass.Load();
 
     // open destination connection
     //  .. and create a new instance of SQLBulkCopy with the dest connection
     bulkCopyInstance.WriteToServer(aCustomReaderClass);
     // close connection and you're done!
