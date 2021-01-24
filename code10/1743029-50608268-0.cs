    public Scoreboard(string data)
    {
        data = data; // << HERE
        for(int i = 0; i < strData.Length; i++)
        {
            data += strData [i];
            data += ",";
        }
    }
