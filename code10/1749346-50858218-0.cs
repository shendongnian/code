    void Speak(params int[] lines)
    {
        string all = "";
        for(int i=0; i< lines.length; i++)
        all += lines[i];
        Bible.SpeakAsync(all);
    }
