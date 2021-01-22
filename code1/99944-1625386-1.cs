    using System.Runtime.CompilerServices;
    ...
    private int a;
    private int b;
    private int c;
    [MethodImpl(MethodImplOptions.Synchronized)]
    private void changeVars()
    {
      a = 4;
      b = 2;
      c = a+b;
    }
