    public class SomeOtherClassThatDoesStuff
    {
       public event EventHandler SomethingHappened;
    
       public void DoStuff()
       {
          ...
          if( SomethingHappened != null )
             SomethingHappened;
          ...
       }
    }
    
    public class Form1
    {
    
        private void Button1_Click(object sender, EventArgs e )
        {
       
          SomeOtherClassThatDoesStuff o = new SomeOtherClassThatDoesStuff();
          o.SomethingHappened += new EventHandler(EnableTimer);
       
          o.DoStuff();
        }
    
        private void EnableTimer(object sender, EventArgs e )
        {
           myTimer.Enabled = true;
        }
    }
