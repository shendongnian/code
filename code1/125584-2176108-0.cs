    public class send: Form
    {
        public send(Form menuForm)
        {
            menu = menuForm;
        }
        public Form menu { get; private set; }
        //... some other methods and properties
        
        public void SomeButton_Click(object sender, EventArgs e) 
        {
           // you have access to the direct method (provided it is public)
           menu.direct();
        }
    }
