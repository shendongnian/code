            string id = Session.SessionID.ToString();
            String[] users = new String[1000];
            users = (string[])Application["users"];
            int count=0;
            for (int d=0;1000 >d ;d++ )
            {
                if (users == null) { users = new String[1000]; }
                count = d;
                if (users[d] == null) { break; }
            }
            users[count] = id;
            Application["users"] = users;
            string[] usersTable = (string[])Application["users"];
            for (int d=0;1000 >d ;d++ )
            {
                if (usersTable[d] == null) { break; }
            Label1.Text += usersTable[d].ToString()+" | ";
