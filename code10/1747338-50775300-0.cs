    string error="";
    string getCode(string code)
                {
                    int count = code.Length;
                    if (count % 2 == 0)
                    {
                        error = "no";
                    }
                    else
                    {
                        error = "yes";
                        string error_message = "There is something wrong with the code. Program.cs - line 23";
                    }
                    
                    if (error == "yes")
                    return null;
                } 
