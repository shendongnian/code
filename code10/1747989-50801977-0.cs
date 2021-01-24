    string fileName = @"c:\data\score.txt";
    enter code here
    string[] lines = System.IO.File.ReadAllLines(fileName);
    List<string> list = new List<string>();
    foreach (string s in lines)
    {
         list.Add(Convert.ToString(s));
         listReadFile.Items.Add(s);
    }
