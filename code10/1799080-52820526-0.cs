            string id = "5456454";
            foreach (ListItem item in dd1.Items)
            {
                if (item.Text.Contains(id))
                {
                    dd1.Items.Remove(item);
                }
            }
