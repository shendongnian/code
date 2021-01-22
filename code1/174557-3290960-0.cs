    private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
            {
                if (sender != grid.Children[0])
                {
                    var rect = (grid.Children[0] as Rectangle);
                    if (rect != null) rect.RaiseEvent(e);
                }
                else
                {
                    MessageBox.Show("Entered.");
                }
            }
