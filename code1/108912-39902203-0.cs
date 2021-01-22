    // If the DGV does not have Focus prior to a toolbar button Click, 
    // then the toolbar button will have focus after its Click event handler returns.
    // To reliably set focus to the DGV, we need to time it to happen After event handler procedure returns.
    private string m_SelectCellFocus_DataPropertyName = "";
    public void CurrentRow_SelectCellFocus(string sDataPropertyName)
    {
      // This procedure is called by a Toolbar Button's Click Event to select and set focus to a Cell in the DGV's Current Row.
      m_SelectCellFocus_DataPropertyName = sDataPropertyName;
      timer_CellFocus = new System.Timers.Timer(10);
      timer_CellFocus.Elapsed += TimerElapsed_CurrentRowSelectCellFocus;
      timer_CellFocus.Start();
    }
    void TimerElapsed_CurrentRowSelectCellFocus(object sender, System.Timers.ElapsedEventArgs e)
    {
      timer_CellFocus.Stop();
      timer_CellFocus.Elapsed -= TimerElapsed_CurrentRowSelectCellFocus;
      timer_CellFocus.Dispose();
      // We have to Invoke the method to avoid raising a threading error
      this.Invoke((MethodInvoker)delegate
      {
        Select_Cell(m_SelectCellFocus_DataPropertyName);
      });
    }
    private void Select_Cell(string sDataPropertyName)
    {
      /// When the Edit Mode is Enabled, set the initial cell to the Description
      foreach (DataGridViewCell dgvc in this.SelectedCells) 
      {
        // Clear previously selected cells
        dgvc.Selected = false; 
      }
      foreach (DataGridViewCell dgvc in this.CurrentRow.Cells)
      {
        // Select the Cell by its DataPropertyName
        if (dgvc.OwningColumn.DataPropertyName == sDataPropertyName)
        {
          this.CurrentCell = dgvc;
          dgvc.Selected = true;
          this.Focus();
          return;
        }
      }
    }
