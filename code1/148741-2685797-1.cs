    using System;
    using System.Windows.Forms;
    
    class MyDgv : DataGridView {
        public event EventHandler ScrollbarVisibleChanged;
        public MyDgv() {
            this.VerticalScrollBar.VisibleChanged += new EventHandler(VerticalScrollBar_VisibleChanged);
        }
        public bool VerticalScrollbarVisible {
            get { return VerticalScrollBar.Visible; }
        }
        private void VerticalScrollBar_VisibleChanged(object sender, EventArgs e) {
            EventHandler handler = ScrollbarVisibleChanged;
            if (handler != null) handler(this, e);
        } 
    }
