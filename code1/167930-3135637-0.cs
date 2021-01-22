    public class LazyRandomMatrix 
    {
      private int _seed;
      private SHA1 _hashProvider = new SHA1CryptoServiceProvider();
      public LazyRandomMatrix(int seed)
      {
        _seed = seed;
      }
      public int this[int x, int y]
      {
        get
        {
          byte[] data = new byte[12];
          Buffer.BlockCopy(BitConverter.GetBytes(x), 0, data, 0, 4);
          Buffer.BlockCopy(BitConverter.GetBytes(y), 0, data, 4, 4);
          Buffer.BlockCopy(BitConverter.GetBytes(_seed), 0, data, 8, 4);
          
          byte[] hash = _hashProvider.ComputeHash(data);
          return BitConverter.ToInt32(hash, 0);
        }
      }     
    }
