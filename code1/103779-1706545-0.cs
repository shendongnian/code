    protected void Button_Click(object sender, EventArgs e)
    {
       UserControl1.DoMethod();
       UserControl2.DoMethod();
       UserControl3.DoMethod();
    }
    
    public class YourUserControl : UserControl
    { 
       public void DoMethod()
       {
          // Show your ListBoxes
       }
    }
