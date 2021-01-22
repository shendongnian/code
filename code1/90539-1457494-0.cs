    myConn.Open();
    OleDbCommand dataCommand = new OleDbCommand();
    if (ListBox2.Items.Count > 0) {
        foreach (ListItem i in ListBox2.Items) {
            insertContractCmd = ("insert into table column1) values ('"
                                + ListBox2.Items
                                + "')", myConn);
            }
        }
        myConn.Open();
        dataCommand.ExecuteNonQuery();
    }
