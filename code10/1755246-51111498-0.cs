    public class GUI {
       public BusLogic BL = new BusLogic();
       public GUI () {
             BL.SaveData += Save_Data;
       }
    
       public bool Save_Data() {
           DialogResult res = MessageBox.Show("do you want to save data", "", MessageBoxButtons.OkCancel);
           return res.Ok == DialogResult.Ok;
       }
      }
