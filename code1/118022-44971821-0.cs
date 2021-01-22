       using( var idr = connection, SP.......)
    {
        while(idr.read())
    {
    if(Sting.ISNullOrEmpty(idr["ColumnNameFromDB"].ToString())
      //do something
    }
    }
    }
