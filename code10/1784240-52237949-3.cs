    public class MainUIForm : Form
    {
      private Log F2 = new Log();
      
      public void checkBox4_CheckedChanged(object sender, EventArgs e)
      {      
        
          checkBox4.Checked ?
            F2.Show() :
            F2.Hide();
          
       }
    }
