    public class EncryptionFactory {
      public static IEncrypter GetEncrypter() {
        //work out which one to return, maybe based on a config value?
    
        // I'm just going to return an MD5, but you'd want to use a switch statement etc
        // to decide which one to return.
    
        return new MD5Encrypter();
      }
    }
