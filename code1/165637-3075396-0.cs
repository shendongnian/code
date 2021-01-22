    using System;
    using System.Windows.Forms;
    
    class MyDGV : DataGridView {
        public override DataObject GetClipboardContent() {
            if (this.SelectedCells.Count == 1 && this.SelectedCells[0].ColumnIndex == 1) {
                string value = string.Format("{0:N2}", this.SelectedCells[0].Value);
                return new DataObject(DataFormats.Text, value);
            }
            return base.GetClipboardContent();
        }
    }
