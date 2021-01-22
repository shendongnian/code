    public CompilationCD FindTrackInComCD(string track)
    {
        CompilationCD temp = new CompilationCD();
        temp = _cdCollection.Where(cd => cd is CompilationCD)
                            .Cast<CompilationCD>()
                            .Where(com_cd => com_cd.Tracks.ContainsKey(track))
                            .FirstOrDefault();
        
        if (temp != null)
            return temp;
        else throw new ArgumentException("No matches found");
    }
