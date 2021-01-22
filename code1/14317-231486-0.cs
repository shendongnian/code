    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    public class MyListView : ListView {
        private Point mItemStartPos;
        private Point mMouseStartPos;
    
        public MyListView() {
            this.AllowDrop = true;
            this.View = View.LargeIcon;
        }
        protected override CreateParams CreateParams {
            // Turn off LVS_AUTOARRANGE
            get {
                CreateParams parms = base.CreateParams;
                parms.Style &= ~0x100;
                return parms;
            }
        }
        protected override void OnHandleCreated(EventArgs e) {
            // Turn on double-buffering
            base.OnHandleCreated(e);
            SendMessage(this.Handle, 0x1000 + 54, (IntPtr)0x10000, (IntPtr)0x10000);
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
    
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
