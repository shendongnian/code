    using System;
    using IdeaClass;
    namespace TestIdeas
    {
        class Program
        {
            static void Main(string[] args)
            {
                Ideas i = new Ideas();
                Ideas.triggerMany();
                Console.ReadLine();
            }
        }
    }
