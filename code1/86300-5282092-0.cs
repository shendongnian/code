            // Member variable.
            private ListView myListView;
            // Method to resize last column.
            private void ResizeColumn(int width) {
                  myListView.Columns[myListView.Columns.Count - 1].Width = width;
            }                  
            // ListView ClientSizeChanged event handler.
            private void Process_ListViewClientSizeChanged(object sender, EventArgs e)
            {
                  // Get the width to resize the last column.
                  int width = myListView.ClientSize.Width;
                  for (int i = 0; i < myListView.Columns.Count - 1; i++)
                        width -= myListView.Columns[i].Width;
                  // Last column width is growing. Use magic number to resize.
                  if (width >= myListView.Columns[myListView.Columns.Count - 1].Width)
                        myListView.Columns[myListView.Columns.Count - 1].Width = -2;
                  // Last column width is shrinking. 
                  // Asynchronously invoke a method to resize the last column.
                  else
                        myListView.BeginInvoke
                              ((MethodInvoker)delegate { ResizeColumn(width); });
            }
