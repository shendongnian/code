    ddl.Items.AddRange(ds.Tables[0].Rows.Select( row => 
        {
            var listText = row["ListText"];
            var listTypeId = (byte)row["ListTypeID"];
            var listId = row["ListID"];
            var itemText = listTypeId == 0 
                   ? String.Format("{0}:{1}", listTypeID, listId)
                   : String.Format("{0}", listId);
            return new ListItem(listText, itemText);
        }
        ));
