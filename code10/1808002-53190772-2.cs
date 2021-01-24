    public class MyForm
    {
        public Form Parent {get;set;} 
        private void newForm_Load(object sender, EventArgs e)
        {
            if (this.Parent is oldForm) 
            {
               //do some stuff here 
            }
            else
            {
               //Do something different
            }
        }
    }
    
