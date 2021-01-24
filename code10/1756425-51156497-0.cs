     public List<string> elements = new List<string>();
     public List<string> deselect = new List<string>();
        protected void checkList_SelectedIndexChanged(object sender, EventArgs e)
        { foreach(ListItem item in checkList.Items)
            {
                if (item.Selected)
                {
                     elements.Add(item.Text);
                }
                else 
                {
                 deselect.Add(item.Text);
                }
            }
            foreach (object o in elements)
            {   int exists = 0;
                for (int i = 0; i < BullList.Items.Count; i++)
                {
                    if(BullList.Items[i].ToString() == o.ToString())
                    {
                        exists++;
                    }
                }
                if(exists == 0)
                {
                    BullList.Items.Add(o.ToString());
                }
             }
          foreach (object o in deselect)
            {
                for (int i = 0; i < BullList.Items.Count; i++)
                {
                    BullList.Items.Remove(o.ToString());
                }
            }
         }
