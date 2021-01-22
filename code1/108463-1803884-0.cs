    public class Basket : IEnumerable<Fruit>
    {
         private Fruit[] myFruit;
         public int Count { get; private set; }
         
         public IEnumerator<Fruit> GetEnumerator()
         {
            for (int i = 0; i < Count; i++)
               yield return myFruit[i];
         }
         IEnumerator IEnumerable.GetEnumerator()
         {
           return GetEnumerator();
         }
    }
