        listView.BeginUpdate();
        try
        {
            for (int i = 0; i < 100; i++)
            {
                listView.Items.Add("Item " + i);
            }
        }
        finally
        {
            listView.EndUpdate();
        }
