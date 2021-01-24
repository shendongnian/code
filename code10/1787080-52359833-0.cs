    public class RegisterBindingModel : BindableBase
    {
        private string _email;
        public string Email { 
            get{
                return this._email;
            }
            set{
                if ( !string.IsNullOrEmpty(value) )
                {
                    SetProperty(ref this._email, value);
                }
            }
        }
    
        private string _password;
        public string Password {
            get{
                return this._password;
            }
            set{
                if ( !string.IsNullOrEmpty(value) )
                {
                    SetProperty(ref this._password, value);
                }
            }
        }
    
        private string _confirmPassword;
        public string ConfirmPassword {
            get{
                return this._confirmPassword;
            }
            set{
                if ( !string.IsNullOrEmpty(value) )
                {
                    SetProperty(ref this._confirmPassword, value);
                }
            }
        }
    }
