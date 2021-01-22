    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    public class Class1
    {                     
        static void Main()
        {
            var beatles = new LinkedList<string>();
    
            beatles.AddFirst("John");                        
            LinkedListNode<string> nextBeatles = beatles.AddAfter(beatles.First, "Paul");
            nextBeatles = beatles.AddAfter(nextBeatles, "George");
            beatles.AddAfter(nextBeatles, "Ringo");
    
            LinkedListNode<string> paulsNode = beatles.NodeAt(1); // middle's index
            LinkedListNode<string> recentHindrance = beatles.AddBefore(paulsNode, "Yoko");
            recentHindrance = beatles.AddBefore(recentHindrance, "Aunt Mimi");
            beatles.AddBefore(recentHindrance, "Father Jim");
    
    
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
