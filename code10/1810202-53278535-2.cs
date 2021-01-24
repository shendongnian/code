    namespace System.Web.UI.WebControls
    {
        public class Validation
        {
            public Validation()
            {
                //
                // TODO: Add constructor logic here
                //
            }
    
            public bool check_control(Control _control)
            {
                _control.GetType();
    
                if (_control is TextBox)
                {
                    // example of validation
                    if((_control as TextBox).Text == string.Empty)
                    {
                        return true;
                    }
                }
                if (_control is DropDownList)
                {
    
                }
                if (_control is RadioButton)
                {
    
                }
                if (_control is RadioButtonList)
                {
    
                }
                return false;
            }
    
        public bool fn_validator(int current_view = 0, int border = 0, Color? color = null, Panel _panel = null)
        {
            //looops through / iterates all items in form and checks for validation
            color.GetValueOrDefault(Color.Red);
            bool atleastone = false;
                
             foreach (Control a in _panel.Controls.Cast<Control>())
              {
                if (check_control(a, Color.Red, 4))
                {
                    atleastone = true;
                }
              }
             if (atleastone)
             {
                return true;
             }
            return false;
        }
                    
                
                  
           
       
    }
