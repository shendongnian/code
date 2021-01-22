    public partial class YourEntity
    {
       public string Password
       {
            get
            {
                return Crypter.Decrypt(this.PasswordInternal)
            }
            set
            {
                this.PasswordInternal = Crypter.Encrypt(value)
            }
       }
    }
