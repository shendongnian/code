    using static System.Console;
    namespace ExamPrep
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int width = 5;
                for (int row = 1; row <= width; row++)
                {
                    for (int column = 1; column <= row; column++)
                    {
                        Write('*');
                    }
                    Write("\n");
                }
                ReadLine();
            }
        }
    }
 
