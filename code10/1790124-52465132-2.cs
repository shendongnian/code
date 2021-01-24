    public class Index : WorkLoad<int[], int[]>
    {
       public override int[] Run()
       {
          var t = Input[Input.Length - 1];
          for (var i = Input.Length - 1; i > 0; i--)
             Input[i] = Input[i - 1];
          Input[0] = t;
          return Input;
       }
    }
    
    public class Unsafe : WorkLoad<int[], int[]>
    {
       public override unsafe int[] Run()
       {
          fixed (int* p = Input)
          {
             var t = *(p + (Input.Length - 1));
             for (var i = Input.Length - 1; i > 0; i--)
                *(p + i) = *(p + (i - 1));
             *p = t;
          }
          return Input;
       }
    }
    
    public class ArrayCopy : WorkLoad<int[], int[]>
    {
       public override int[] Run()
       {
          var temp = Input[Input.Length - 1];
          Array.Copy(Input, 0, Input, 1, Input.Length - 1);
          Input[0] = temp;
          return Input;
       }
    }
    
    public class BlockCopy : WorkLoad<int[], int[]>
    {
       public override int[] Run()
       {
          var temp = Input[Input.Length - 1];
          Buffer.BlockCopy(Input, 0, Input, 1, Input.Length - 1);
          Input[0] = temp;
          return Input;
       }
    }
