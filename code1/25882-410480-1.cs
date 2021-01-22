    public class Class1
    {                     
        static void Main()
        {
            var beatles = new LinkedList<string>();
            beatles.AddFirst("John");                        
            LinkedListNode<string> nextBeatles = beatles.AddAfter(beatles.First, "Paul");
            nextBeatles = beatles.AddAfter(nextBeatles, "George");
            nextBeatles = beatles.AddAfter(nextBeatles, "Ringo");
            // change the 1 to your 5th line
            LinkedListNode<string> paulsNode = beatles.NodeAt(1); 
            LinkedListNode<string> recentHindrance = beatles.AddBefore(paulsNode, "Yoko");
            recentHindrance = beatles.AddBefore(recentHindrance, "Aunt Mimi");
            recentHindrance = beatles.AddBefore(recentHindrance, "Father Jim");
            Console.WriteLine("{0}", string.Join("\n", beatles.ToArray()));
            Console.ReadLine();                       
        }
    }
    public static class Helper
    {
        public static LinkedListNode<T> NodeAt<T>(this LinkedList<T> l, int index)
        {
            LinkedListNode<T> x = l.First;
            
            while ((index--) > 0) x = x.Next;
            return x;
        }
    }
