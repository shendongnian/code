	    public class LoginModel : ViewModelBase
	    {
	        public string TextBoxNameFocus { get; set; }
	        public void SetFocus(string PropertyName)
	        {
	            PropertyInfo propertyInfo = this.GetType().GetProperty(PropertyName);
	            propertyInfo.SetValue(this, Convert.ChangeType("True", propertyInfo.PropertyType), null);
	            OnPropertyChanged(PropertyName);
	        }
        
	        private void ExampleFocus(){
    
	        	SetFocus("TextBoxNameFocus");
    
	        }
        }
