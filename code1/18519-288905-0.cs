            if (listView.SelectedIndices.Count > 0)
            {
                int oldSelection = listView.SelectedIndices[0];
                listView.SelectedIndices.Clear();
                if (oldSelection + 1 >= listView.Items.Count)
                    listView.SelectedIndices.Add(0);
                else
                    listView.SelectedIndices.Add(oldSelection + 1);
            }
