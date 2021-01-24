    using static System.Console;
    namespace ExamPrep
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int maxHeight = 5;
                for (int height = 0; height < maxHeight; height++)
                {
                    for (int width = 0; width <= height; width++)
                    {
                        Write('*');
                    }
                    Write("\n");
                }
                ReadLine();
            }
        }
    }
