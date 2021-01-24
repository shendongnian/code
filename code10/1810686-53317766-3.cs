    private System.Timers.Timer dragTimer;
    void productsDataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
       var dataGrid = (DataGrid)sender;
    
       dragTimer = new System.Timers.Timer(400);
       System.Timers.ElapsedEventHandler elapsed = null;
       elapsed = (s, ee) =>
       {
          dragTimer.Elapsed -= elapsed;
    
          dataGrid.Dispatcher.Invoke(() =>
          {
             rowIndex = GetCurrentRowIndex(e.GetPosition, dataGrid);
             if (rowIndex < 0) return;
             dataGrid.SelectedIndex = rowIndex;
             object selectedEmp = dataGrid.Items[rowIndex];
             if (selectedEmp == null) return;
             DragDropEffects dragdropeffects = DragDropEffects.Move;
             if (DragDrop.DoDragDrop(dataGrid, selectedEmp, dragdropeffects)
                   != DragDropEffects.None)
             {
                dataGrid.SelectedItem = selectedEmp;
             }
          });
       };
    
       dragTimer.Elapsed += elapsed;
       dragTimer.Start();
    }
    
    private void productsDataGrid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
       if (dragTimer == null) return;
       dragTimer.Stop();
       dragTimer.Dispose();
       dragTimer = null;
    }
