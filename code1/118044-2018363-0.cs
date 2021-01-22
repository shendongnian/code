    class HelpForm : Form
    {
       private HelpForm _instance;
       public static HelpForm GetInstance()
       {
         if(_instance == null) _instance = new HelpForm();
         return _instance; 
       }
    }
    
    .......
    
    private void heToolStripMenuItem_Click(object sender, EventArgs e)
    {
         HelpForm form = HelpForm.GetInstance();
         if(!form.Visible)
         {
           form.Show();
         }
         else
         {
           form.BringToFront();
         }
    }
