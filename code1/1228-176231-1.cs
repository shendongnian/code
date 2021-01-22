    int x = 0;
    YourDatabaseResultSet data = new YourDatabaseResultSet();
    if (cond1)
        if (int.TryParse(x_input, x)){
            data = YourDatabaseAccessMethod("my_proc_name", 2, x);
        }
        else{
            x = -1;
            // do something to report "Can't Parse"    
        }
    }
    else {
        x = y;
        data = YourDatabaseAccessMethod("my_proc_name", 
           new SqlParameter("@param1", 2),
           new SqlParameter("@param2", x));
    }
            
