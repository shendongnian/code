    		//This is the pay 
		SQLite bd = new SQLite();
		string searchString = "<REC>";
		int endIndex = content.IndexOf(searchString);
		s = content.Substring(0, endIndex);
        bd.Update(s);
    
        ....
    
        public bool Update(object value)
        {
           using (var conn = new SQLiteConnection(...))
           {
                conn.Open();
                // GetId(). 
                //reconstruct sql command then 
                //do insert
           }
           // this way only use single conn for both getId and Insert
        }
		
 
