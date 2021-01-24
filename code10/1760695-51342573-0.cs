    public class BigClass
    {
        public SecretClass not_so_secret = new VerySecretClass();
        public abstract class SecretClass
        {
        }
        private class VerySecretClass : SecretClass
        {
        }
    }
