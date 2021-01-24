    using System;
    
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
                         if (answer == "scan") {
                            if (hideMode) {
                                Console.WriteLine($"can't scan files for viruses");
                             } else {
                                fileIndex++;
                                Console.WriteLine($"scanning file {fileIndex}");
                             }
                         }
                         
                         if(answer == "hide")
                         {
                            Console.WriteLine($"can't scan files for viruses");
                            hideMode=true;
                         }
                         
                         if (answer == "unhide")
                         {
                            fileIndex=fileIndex+1;
                            Console.WriteLine($"scanning file {fileIndex}");
                            hideMode=false;
                         }
    
                         if (answer == "game over")
                         {
                            Console.WriteLine($"run");
                            heDoesntKnow = false;
                         }
              }
         }
     }}
