    public static class SocketExtensions
    {
      public static bool IsConnected(this Socket @this)
      {
        return !(@this.Poll(1, SelectMode.SelectRead) && @this.Available == 0);
      }
    }
