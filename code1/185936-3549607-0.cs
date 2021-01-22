    //SQL Connection and SQL Command have been created separately as _conn and _cmd
    using(SqlDataReader _read = _cmd.ExecuteReader())
    {
        string name = "";
        string position = "";
        string date = "";
        while(_read.Read()) //don't really do this, make sure you're checking for nulls and such
        {
           name = _read.GetString(0);
           position = _read.GetString(1);
           date = _read.GetString(2);
           AddLineToLines(string.Format("{0}|{1}|{2}", name, position, date));
              //AddLineToLines is a call to add to your list of lines so you can 
              // write your file.
        }
    }
