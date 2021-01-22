    if (listview1.Items.Count > 0)
            {
                for (int a = listview1.Items.Count -1; a > 0 ; a--)
                {
                    listview1.Items.RemoveAt(a);
                }
                    listview1.Refresh();
                
            }
