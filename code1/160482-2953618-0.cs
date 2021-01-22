    public class Form2 : Form 
    {
        public Form2( Form1 form1 )
        { 
            this.form1 = form1;
        }
    
        /// ...
        public void Work()
        {
            // ...
            form1.Update( someData );
        }
    }
