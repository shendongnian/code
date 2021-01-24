      for (int i = 0; i < lsBox.Items.Count; i++)
            {
                var item = lsBox.Items[i];
                string[] selectecvalues = new string[] { "1", "3", "6", "9" };
    
                if (selectecvalues.Contains(item.Value)) // or item.Text  if you like
                {
                    lsBox.Items[i].Selected = true;
                }
            }
