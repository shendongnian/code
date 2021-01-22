       public class MainForm : Form
       {
          private static MainForm mainForm;
    
          public static MainForm { get { return mainForm; } }
    
          public MainForm()
          {
             mainForm = this;
          }
       }
    
    
       // When the ESC key is pressed...
       MainForm.MainForm.Close();
