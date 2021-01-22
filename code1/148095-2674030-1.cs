    public class MyTextBox: TextBox  
    { 
        public MyTextBox()   
        {   
            this.Attributes.Add("OnLoad", "jsFunction();");        
        }   
    }
