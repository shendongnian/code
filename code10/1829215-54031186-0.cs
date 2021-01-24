    using System;
    using System.IO;
    namespace New_Folder
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("What Event Would You Like To Buy A Ticket For?");
                string EventUpdate = Console.ReadLine();
                string folderPath = ("TextFiles");
                string fileName = EventUpdate + ".txt";
                string filePath = fileName; //creats file path using FolderPath Plus users Input
                string[] Contents = File.ReadAllLines(filePath); //Puts each line content into array element
                foreach (var line in Contents)
                {
                    System.Console.WriteLine(line); //displays the txt file that was called for
                }
                Console.WriteLine("\n");
                int LineWithAmountOfTicketIndex = 3;
                string LineWithAmountOfTicketText = Contents[LineWithAmountOfTicketIndex];
                string[] AmountLineContent = LineWithAmountOfTicketText.Split(':'); // Splits text by ':' sign and puts elements into an array, e.g. "one:two" would be split into "one" and "two"
                int TicketNumber = Int32.Parse(AmountLineContent[1]); // Parses the ticket number part from a string to int (check out TryParse() as well)
                int SubtractedTicketNumber = --TicketNumber; //subtract one from ticket number before assigning to a variable
                string NewText = $"{AmountLineContent[0]}: {SubtractedTicketNumber}";
                string NewTempFile = folderPath + EventUpdate + ".txt";
                string file = filePath;
                File.WriteAllText(file, File.ReadAllText(file).Replace(LineWithAmountOfTicketText, NewText));
                using(var sourceFile = File.OpenText(file))
                {
                    // Create a temporary file path where we can write modify lines
                    string tempFile = Path.Combine(Path.GetDirectoryName(file), NewTempFile);
                    // Open a stream for the temporary file
                    using(var tempFileStream = new StreamWriter(tempFile))
                    {
                        string line;
                        // read lines while the file has them
                        while ((line = sourceFile.ReadLine()) != null)
                        {
                            // Do the Line replacement
                            line = line.Replace(LineWithAmountOfTicketText, NewText);
                            // Write the modified line to the new file
                            tempFileStream.WriteLine(line);
                        }
                    }
                }
                // Replace the original file with the temporary one
                File.Replace(NewTempFile, file, null);
            }
        }
    }
