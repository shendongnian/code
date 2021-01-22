    using PBKDF2 = System.Security.Cryptography.Rfc2898DeriveBytes;
    
    class Example {
        byte[] mySalt = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
        void Initialize( string password ) {
            PBKDF2 kdf = new PBKDF2( password, mySalt );
            // Then you have your algorithm
            // When you need a key: use:
            byte[] key = kdf.GetBytes( 16 ); // for a 128-bit key (16*8=128)
            
            // You can specify how many bytes you need. Same for IV.
            byte[] iv = kdf.GetBytes( 16 ); // 128 bits again.
            
            // And then call your constructor, etc.
            // ...
        }
    }
