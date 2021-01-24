    public class MyFactory
    {
        public IKeyGen GenerateKeyProvider()
        {
            return new KeyGen();
        }
        public interface IKeyGen 
        {
          int GetKey(string arg);
        }
        private class KeyGen : IKeyGen
        {
            public int GetKey(string arg)
            {
                return 1;
            }
        }
    }
