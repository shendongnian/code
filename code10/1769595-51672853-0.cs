    using System;
    namespace csharptestchis
    {
        class Program
        {
            static void Main(string[] args)
            {
                for (int i = 0; i <= 255; i++)
                {
                    char ch = (char)i;
                    bool isSymbol = Char.IsSymbol(ch);
                    bool isPunctuation = Char.IsPunctuation(ch);
                    Console.WriteLine($"{i}/{ch}: IsSymbol={isSymbol}, IsPunctuation={isPunctuation} ");
                }
            }
        }
    }
