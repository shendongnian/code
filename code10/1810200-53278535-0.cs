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
    
            public bool fn_validator(int current_view = 0, int border = 0, Color? color = null, MultiView mView = null)
            {
                //looops through / iterates all items in form and checks for validation
                color.GetValueOrDefault(Color.Red);
    
                  
                    View a = mView.GetActiveView();
                    if (a.HasControls())
                    {
                        for (int i = 0; i < a.Controls.Count; i++)
                        {
                            Control control = a.Controls[i];
                            if(check_control(control))
                            {
                              // set css styling for control
                              return true; // so we can check on click next page button to deny
                            }
                         }
                    }
    
                return false;
    
            }
    
        }
    }
