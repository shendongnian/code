    public class User
    {
        public String UserName     { get; set; }
        public Byte[] PasswordHash { get; set; }
        public Byte[] PasswordSalt { get; set; }
        public Boolean ValidatePassword(String inputPassword)
        {
            Hash[] inputHash = Crypto.GetHash( inputPassword, this.PasswordSalt );
            return Crypto.CompareHashes( this.PasswordHash, inputHash );
        }
        public void ResetSalt()
        {
            this.PasswordSalt = Crypto.GetRandomBytes( 16 );
        }
    }
    public static void DoReadOnlyStuffWithUser( User user )
    {
        ...
    }
    public static void WriteStuffToUser( User user )
    {
        ...
    }
