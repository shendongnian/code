    public void Play()
    {  
        Note note = new Note();
        foreach(Note MyNote23 in notes)
        {
            // I need to access the properties here
            int f = note.Frequency;
            int d = note.Duration;         
        }
    }
