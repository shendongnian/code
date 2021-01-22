        string inputString;
        List<string> List = new List<string>();
        try
        {
            StreamReader streamReader = File.OpenText(FP.Trim()); // FP is the filepath of TNS file
            inputString = streamReader.ReadToEnd();
            string[] temp = inputString.Split(new string[] {Environment.NewLine},StringSplitOptions.None);
            for (int i = 0; i < temp.Length ;i++ )
            {
                if (temp[i].Trim(' ', '(').Contains("DESCRIPTION"))
                {                   
                    string DS = temp[i-1].Trim('=', ' ');
                    List.Add(DS);
                }             
                
            }
            streamReader.Close();
        }
        catch (Exception EX)
        {
        }
        
        return List;
    }
