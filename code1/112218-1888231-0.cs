    public class Form1: Form
    {
         private Form2: form2;
         private bool doDbQuery;
         public Form1()
         {
             doDbQuery = true;
         }
         public void SomeMethod()
         {
             if (form2 != null)
             {
                  form2 = new Form();
             }
             if (doDbQuery)
             {
                 // do DB query
                 // take a note of the information you retrieve
                 doDbQuery = false;
             }
             // pass this information to Form2 for it to display.
             DialogResult result = form2.Execute(...);
         }
    }
    public class Form2 : Form    
    {        
        public Form2()       
        {
        }
        public DialogResult Execute(...)
        {
            // use the execute method to inject the data you require for the form
            return ShowDialog;
        }
    }
