    public class GUI {
       public BusLogic BL = new BusLogic();
       public GUI () {
             BL.ShouldSaveData += Should_Save_Data;
        }
    
        public bool Should_Save_Data() {
           DialogResult res = MessageBox.Show("do you want to save data", "", MessageBoxButtons.OkCancel);
           return res.Ok == DialogResult.Ok;
        }
        private void iExit_ItemClick(object sender, ItemClickEventArgs e) { 
           _isFormClosing = true;
           if (_isDataModified) BL.SaveOrRejectChanges();
        }
    }
