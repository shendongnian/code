    private void OldFaithful_ItemDragStarting(object sender, ItemDragEventArgs e)
            {
                SelectionCollection selections = e.Data as SelectionCollection;
    
                if (selections != null)
                {
                    IEnumerable<CXSectionControl> draggedItems = selections.Select(s => s.Item as YOUREXCPECTEDOBJECTTYPE);
                    foreach (YOUREXCPECTEDOBJECTTYPE x in draggedItems)
                    {
                        MessageBox.Show(x.GetType().ToString());
                    }
    
                }
            }
