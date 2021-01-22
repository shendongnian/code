    public class Form1
    {
        public Form1()
        {    
            this.Closed += MyClosedHandler;
        }
    
        protected void MyClosedHandler(object sender, EventArgs e)
        {
            // Handle the Event here.
        }
    }
