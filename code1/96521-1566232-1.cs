        String ProjectDDL1 = ProjDDL1.SelectedItem.Text;
        ClientPJ mypj = new ClientPJ((DataSet)(Session["Client_ProjectDS"]));
        //DataSet DS4DDL1 = mypj.searchPJ("chemistry");
        ListBox listBox = new ListBox();
        DataSet DS4DDL1 = mypj.searchPJ(listBox, "chemistry"); //Does not work
        ProjList.Items.Clear();
        foreach (DataRow dr in DS4DDL1.Tables[0].Rows)
        {
            //only add item with valid UID
            if (dr[0].ToString().Trim().Length > 0)
                //use UID as the item value
                ProjList.Items.Add(new ListItem(string.Format("{0}", dr[0].ToString())));
        }
    }
