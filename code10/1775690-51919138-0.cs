    static void Main()
    {
        string data = "DisplayName=[s9dFSQ]Height=[rPBM7]User=[5cY]Date=[KJn7Zzd1f]";
    
        Console.WriteLine(RemoveBracketsContent(data)); // prints DisplayName=Height=User=Date=
    }
    
    static string RemoveBracketsContent(string data)
    {
        string result = string.Empty;
        bool brackedStarted = false;
    
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].Equals('['))
            {
                brackedStarted = true;
                continue;
            }
            else if (data[i].Equals(']'))
            {
                brackedStarted = false;
                continue;
            }
    
            if (brackedStarted)
            {
                continue;
            }
    
            result += data[i];
        }
    
        return result;
    }
