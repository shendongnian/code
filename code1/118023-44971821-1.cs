       using( var idr = connection, SP.......)
       {
           while(idr.read())
           {
              if(String.IsNullOrEmpty(idr["ColumnNameFromDB"].ToString())
              //do something
           }
       }
