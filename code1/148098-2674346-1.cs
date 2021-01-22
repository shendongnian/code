    public partial class MyTextBox: TextBox 
    {
        protected override void OnInit(EventArgs e)  
        {  
            base.OnInit(e);   
            Attributes.Add("OnLoad", "jsFunction();");               
        }  
    }
