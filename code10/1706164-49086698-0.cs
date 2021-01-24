    public class Foo //this is your class
    {
        void readFromTextFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            //Read the first line of text
            string line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                Console.WriteLine(line);
                //Read the next line
               line = sr.ReadLine();
            }
            //close the file
            sr.Close();
        }
    }
