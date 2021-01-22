    string TestStr = "The frog jumped over the hill";
    char[] KillChar = {'w', 'l'};
    for(int i = 0; i < TestStr.Length; i++)
    {
        for(int E = 0; E < KillChar.Length; E++)
        {
            if(KillChar[E] == TestStr[i])
            {
                i = TestStr.Length; //Ends First Loop
                break; //Ends Second Loop
            }
        }
    }
