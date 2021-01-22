    class Test
    {
      public static Main () : void
      {
        def input = System.Console.ReadLine ().Split (' ');
        def ch = System.Char.Parse (input[0]);
        def a  = System.Int32.Parse (input[1]);
        def d =  System.Int32.Parse (input[2]);
        def m =  System.Int32.Parse (input[3]);
        
        System.Console.WriteLine ("ch:{0} a:{1} d:{2} m:{3}",  ch, a, d, m);
      }
    }
