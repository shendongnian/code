Dictionary<string,int> index = new Dictionary<string,int>();
using (StreamReader sr = new StreamReader("IndexFile.txt")) 
{
    String line;
    while ((line = sr.ReadLine()) != null)
    {
        string[] parts = line.Split(' ');  // Break the line into the name & line number
        index.Add(parts[0], Convert.ToInt32(parts[1]));
    }
}
