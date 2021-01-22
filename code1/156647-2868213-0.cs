    public partial class DbTableItem
    {
      public String UnencryptedPass
      {
        get
        {
           return  Crypter.Decrypt(this.Pass);
        }
      
        set
        {
           this.Pass = Crypter.Encrypt(value)
        }
      }
    }
