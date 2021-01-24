    public class RandomIntegers {
       private static List<int> myNumbersA = new List<int>();
       private static List<int> myNumbersB = new List<int>();
   
       public static void  RandomValues(out int a,out int b)
       {
          if (myNumbersA.Count == 0)
          {
               for (int i = 0; i < 10; i++)
               {
                   myNumbersA.Add(i + 1);
                   myNumbersB.Add(i + 1);
               }
           }
           a = myNumbersA[Random.Range(0, myNumbersA.Count)];
           b = myNumbersB[Random.Range(0, myNumbersB.Count)];
           Debug.Log(a);
           Debug.Log(b);
        }
    }
