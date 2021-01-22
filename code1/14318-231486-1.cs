    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class MyListView : ListView {
      private Point mItemStartPos;
      private Point mMouseStartPos;
    
      public MyListView() {
        this.AllowDrop = true;
        this.View = View.LargeIcon;
        this.AutoArrange = false;
        this.DoubleBuffered = true;
      }
    
      protected override void OnDragEnter(DragEventArgs e) {
        if (e.Data.GetData(typeof(ListViewItem)) != null) e.Effect = DragDropEffects.Move;
      }
      protected override void OnItemDrag(ItemDragEventArgs e) {
        // Start dragging
        ListViewItem item = e.Item as ListViewItem;
        mItemStartPos = item.Position;
        mMouseStartPos = Control.MousePosition;
        this.DoDragDrop(item, DragDropEffects.Move);
      }
      protected override void OnDragOver(DragEventArgs e) {
        // Move icon
        ListViewItem item = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
        if (item != null) {
          Point mousePos = Control.MousePosition;
          item.Position = new Point(mItemStartPos.X + mousePos.X - mMouseStartPos.X,
              mItemStartPos.Y + mousePos.Y - mMouseStartPos.Y);
        }
      }
    }
