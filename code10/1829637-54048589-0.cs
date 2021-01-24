    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp27
    {
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] students = { "Fred", "Mary", "Yusef", "Kyle", "Sophie", "Lydia", "Max", "Donald", "Yasmin", "Archie"};
            string[] shuffleStudents = students.OrderBy(x => random.Next()).ToArray();
            Console.WriteLine("Your pairs for Secret Santa has been completed!");
            int count = 0;
           
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0} and {1} \n", shuffleStudents[count], shuffleStudents[count+1]);
                for (int i = 0; i < 2; i++)
                {
                    count++;
                }
            }
            Console.Read();
        }
    }
}
