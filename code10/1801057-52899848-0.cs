      protected override void OnCellEnter(DataGridViewCellEventArgs e)
      {
         base.OnCellEnter(e);
         if (!this.CurrentCell.Displayed)
         {
            this.FirstDisplayedScrollingColumnIndex = e.ColumnIndex;
         }
      }
