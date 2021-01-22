     public class Test : System.Windows.Forms.TextBox
     {
        public new string Text
        {
            get { return base.Text; }
            private set { base.Text = value; }
        }
    
        public Test()
        {
          base.Text = "hello";
        }
     }
  
     Test test = new Test(); // Create an instance of it
     string text = test.Text;
     text.Text = "hello world"; // comp error 
