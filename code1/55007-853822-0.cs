    public virtual List<IBug> FillBugs()
    {
        // is this actually correct or did you mix up the concatenation order?
        // either way, I suggest Path.Combine() instead
        string folder = xmlStorageLocation + "bugs" + Path.DirectorySeparatorChar;
        List<IBug> bugs = new List<IBug>();
        foreach (string file in Directory.GetFiles(folder, "*.xml",
            SearchOption.TopDirectoryOnly))
        {
            // i guess IBug is not actually an interface even though it starts 
            // with "I" since you made one in your code
            bugs.Add(new IBug {
                Title = file, Id = 0 /* don't know where you get an ID */ });
        }
        return bugs;
    }
