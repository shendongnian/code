    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static List<string> area1 = new List<string>();
            static List<string> area2 = new List<string>();
            static int areaHeights = 0;
    
            static void Main(string[] args)
            {
                // Number of rows for each area
                areaHeights = (Console.WindowHeight - 2) / 2;
    
                drawScreen();
    
                int i = 0;
                while (true)
                {
                    i++;
    
                    // jumb between areas
                    if (i % 2 == 0)
                        AddLineToBuffer(ref area1, Console.ReadLine());
                    else
                        AddLineToBuffer(ref area2, Console.ReadLine());
    
                    drawScreen();
                }
            }
    
            private static void AddLineToBuffer(ref List<string> areaBuffer, string line)
            {
                areaBuffer.Insert(0, line);
    
                if (areaBuffer.Count == areaHeights)
                {
                    areaBuffer.RemoveAt(areaHeights - 1);
                }
            }
    
    
            private static void drawScreen()
            {
                Console.Clear();
                
                // Draw the area divider
                for (int i = 0; i < Console.BufferWidth; i++)
                {
                    Console.SetCursorPosition(i, areaHeights);
                    Console.Write('=');
                }
    
                int currentLine = areaHeights - 1;
    
                for (int i = 0; i < area1.Count; i++)
                {
                    Console.SetCursorPosition(0, currentLine - (i + 1));
                    Console.WriteLine(area1[i]);
                    
                }
    
                currentLine = (areaHeights * 2);
                for(int i = 0; i < area2.Count; i++)
                {
                    Console.SetCursorPosition(0, currentLine - (i + 1));
                    Console.WriteLine(area2[i]);
                }
    
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("> ");
                
            }
    
        }
    }
