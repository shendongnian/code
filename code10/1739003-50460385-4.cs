    namespace WhileLoop
    {
        class AntivirusScan
        {
             static void Main(string[] args)
            {
    int fileIndex = 0;
    bool hideMode = false;
    bool heDoesntKnow = true;
    
              while (heDoesntKnow)
                {
                    string answer = Console.ReadLine();
                    if (answer == "scan" && !hideMode)
                    {
                        fileIndex = fileIndex + 1;
                        Console.WriteLine($"scanning file {fileIndex}");
                    }
    
                    if (answer == "unhide")
                    {
                        fileIndex = fileIndex + 1;
                        Console.WriteLine($"scanning file {fileIndex}");
                        hideMode = false;
                    }
    
                    if (hideMode == true)
                    {
                        Console.WriteLine($"can't scan files for viruses");
                    }
                    if (answer == "hide")
                    {
                        Console.WriteLine($"can't scan files for viruses");
                        hideMode = true;
                    }
                    
    
                    if (answer == "game over")
                    {
                        Console.WriteLine("run");
                        heDoesntKnow = false;
                    }
                }
         }
     }}
