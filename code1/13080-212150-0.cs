try this
    public static string readFile(string path)
    {
         StreamReader SR;
        string S;
        SR = File.OpenText(path);
        S = SR.ReadToEnd();
       SR.Close();
        return stringFromFile.ToString();
    }
