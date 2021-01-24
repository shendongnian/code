    string linesc = File.ReadAllText(path);
    string[] linesx = linesc.Split('|');
    foreach (string s in linesx)
    {
        string new2=s.Replace(Environment.NewLine, " ")
            .Replace("Names : ", "")
            .Replace("Age : ", "")
            .Replace("Location : ", "") + "\n";
        File.AppendAllText(path2 + "myfile.txt", new2 + Environment.NewLine);
    }
