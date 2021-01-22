    public partial class MyTextBox: TextBox 
    {
        protected override void OnInit(EventArgs e)  
        {  
            base.OnLoad(e);   
            Attributes.Add("OnLoad", "jsFunction();");               
        }  
    }
