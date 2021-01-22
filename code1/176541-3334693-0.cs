    static void Main(string[] args)
        {
            db1DataSet set = new db1DataSet();
            set.Users.AddUsersRow("asd", "asd");
    
            foreach (DataRow row in set.Users.Rows)
            {
                object foo = row.RowState; // Confirm row state in debugger.
            }
    
            UsersTableAdapter adap = new UsersTableAdapter();
            adap.Update(set.Users);
    
            Console.Read();
        }
