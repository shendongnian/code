    public class Form1
    {
      private Func<IMessageBoxRepository> _mbr;
      public Form1(Func<IMessageBoxRepository> mbr)
      {
        _mbr = mbr;
      }
      public void OnError(string msg)
      {
        var mb = _mbr();
        mb.Show(msg);
      }
    }
