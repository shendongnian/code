	    public class LoginModel : ViewModelBase
	    {
	      
        public string txtLabel_IsFocused { get; set; }                 
        public string butEdit_IsEnabled { get; set; }                
        public void SetProperty(string PropertyName, string value)
        {
            System.Reflection.PropertyInfo propertyInfo = this.GetType().GetProperty(PropertyName);
            propertyInfo.SetValue(this, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            OnPropertyChanged(PropertyName);
        }                
        private void Example_function(){
            SetProperty("butEdit_IsEnabled", "False");
            SetProperty("txtLabel_IsFocused", "True");        
        }
        }
