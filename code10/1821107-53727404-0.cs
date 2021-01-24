    class Program
    {
        static void Main(string[] args)
        {
            string directory = @"E:\TempFiles\"; //Name of directory containing text files and PDFs
            //Get text file with names for PDFs...
            string filenames = File.ReadAllText(directory + "names.txt");
            //Removed quotes, but can be done differently, and split by space, which may not work for all your cases, but gets going in the right direction...
            string[] listFilenames = filenames.Replace("\"", "").Split('\t');
            int i = 0; //Used to access list of filnames...
            foreach (string file in Directory.GetFiles(directory))
            {
                //Skip text file...
                if (!file.EndsWith(".txt"))
                {
                    //Rename file...
                    File.Move(file, directory + listFilenames[i] + ".pdf");
                    i++;
                }
            }
        }
    }
