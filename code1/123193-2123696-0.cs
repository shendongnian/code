    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class AutoSizeGrid : DataGridView {
      private int gridHeight;
      private bool resizing;
      protected override void OnClientSizeChanged(EventArgs e) {
        if (!resizing) gridHeight = this.ClientSize.Height;
        base.OnClientSizeChanged(e);
      }
      protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e) {
        setGridHeight();
        base.OnRowsAdded(e);
      }
      protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e) {
        setGridHeight();
        base.OnRowsRemoved(e);
      }
      protected override void OnHandleCreated(EventArgs e) {
        this.BeginInvoke(new MethodInvoker(setGridHeight));
        base.OnHandleCreated(e);
      }
      private void setGridHeight() {
        if (this.DesignMode || this.RowCount > 99) return;
        int height = this.ColumnHeadersHeight + 2;
        if (this.HorizontalScrollBar.Visible) height += SystemInformation.HorizontalScrollBarHeight;
        for (int row = 0; row < this.RowCount; ++row) {
          height = Math.Min(gridHeight, height + this.Rows[row].Height);
          if (height >= gridHeight) break;
        }
        resizing = true;
        this.ClientSize = new Size(this.ClientSize.Width, height);
        resizing = false;
        if (height < gridHeight && this.RowCount > 0) this.FirstDisplayedScrollingRowIndex = 0;
      }
    }
