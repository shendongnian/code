    public class DaysOfTheWeek : System.Collections.IEnumerable
    {
         string[] days = { "Sun", "Mon", "Tue", "Wed", "Thr", "Fri", "Sat" };
         //This is the iterator!!!
         public System.Collections.IEnumerator GetEnumerator()
         {
             for (int i = 0; i < days.Length; i++)
             {
                 yield return days[i];
             }
         }
    }
    class TestDaysOfTheWeek
    {
        static void Main()
        {
            // Create an instance of the collection class
            DaysOfTheWeek week = new DaysOfTheWeek();
            // Iterate with foreach - this is using the iterator!!! When the compiler
            //detects your iterator, it will automatically generate the Current, 
            //MoveNext and Dispose methods of the IEnumerator or IEnumerator<T> interface
            foreach (string day in week)
            {
                System.Console.Write(day + " ");
            }
        }
    }
    // Output: Sun Mon Tue Wed Thr Fri Sat
