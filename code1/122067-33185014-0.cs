            AddRemoveItemsListBox(lstSourceSkills, lstDestinationSkills);
        }
        protected void lbRemovefromDestination_Click(object sender, EventArgs e)
        {
            AddRemoveItemsListBox(lstDestinationSkills, lstSourceSkills);
        }
        private void AddRemoveItemsListBox(ListBox source, ListBox destination)
        {
            List<ListItem> toBeRemoved = new List<ListItem>();
            foreach (ListItem item in source.Items)
            {
                if (item.Selected)
                {
                    toBeRemoved.Add(item);
                    destination.Items.Add(item);
                }
            }
            foreach (ListItem item in toBeRemoved) source.Items.Remove(item);
        }
