    public static void Main(string[] args)
    {
        // I want to modify the records but I'm not interested
        // in knowing how manyof them  have been modified.
        ModifyRecords();
    }
    
    public static Int32 ModifyRecords()
    {
        Int32 affectedRecords = 0;
    
        for (Int32 i = 0; i < s_Records.Count; ++i)
        {
            Record r = s_Records[i];
    
            if (String.IsNullOrWhiteSpace(r.Name))
            {
                r.Name = "Default Name";
                ++affectedRecords;
            }
        }
    
        return affectedRecords;
    }
