    public class MainUIForm : Form
    {
      private Log F2  = null;
      
      public void checkBox4_CheckedChanged(object sender, EventArgs e)
      {      
        
          if (checkBox4.Checked == true)
          {
            F2 = new Log();
            F2.Show();
          }
          else if (checkBox4.Checked == false)
          {
            F2.Hide(); // for just hiding it
            F2.Close(); // for closing which will dispose it
          }
       }
    }
