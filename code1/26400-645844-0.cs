    public String FindRecord()
    {
        String[] lines = File.ReadAllLines("MyFile.csv");
        Array.Sort(lines, CompareByBestMaleName);
        return lines[0];
    }
    int SortByBestMaleName(String a, String b)
    {
        String[] ap = a.Split();            
        String[] bp = b.Split();
         // Always rank male higher
        if (ap[1] == "m" && bp[1] == "f") { return 1; }
        if (ap[1] == "f" && bp[1] == "m") { return -1; }
        // Compare by score
        return int.Parse(ap[2]).CompareTo(int.Parse(bp[2]));
    }
