    public class Test
    {
      public static implicit operator int(Test v)
      {
        return 12;
      }
    }
    
    (int)(object)new Test() //this will fail
    Convert.ToInt32((object)new Test()) //this will fail
    (int)(dynamic)(object)new Test() //this will pass
