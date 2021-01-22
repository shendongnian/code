    public static class Ext
    {
         [TestCase(1.1, Result = 1)]
         [TestCase(0.9, Result = 1)]
         public static int ToRoundedInt(this double d)
         {
             return (int) Math.Round(d);
         }
    }
