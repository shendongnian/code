        class FileProcess
    {
        string path = @"c:\PhoneBook\PhoneBook.txt";
        public void writeFile(string text1,string text2)
        {
            using (StreamWriter sw = new StreamWriter(path,true))
            {
                sw.WriteLine(text1);
                sw.WriteLine(text2);
            }
        }
    }
