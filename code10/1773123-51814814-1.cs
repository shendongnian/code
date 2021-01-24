    Console.WriteLine("Enter name of file then add .txt");
                var fileName = Console.ReadLine();
    
                var folderPath = @"H:\test\";
                var filePath = folderPath + fileName;
    
    
                Console.WriteLine(filePath);
    
                Console.WriteLine("Enter the text you want to save to that file");
                string[] lines = new string[1];
                var inputTextUser = Console.ReadLine();
                lines[0] = inputTextUser;
    
                //File.AppendAllText(filePath, inputTextUser);
                File.WriteAllLines(filePath, lines);
