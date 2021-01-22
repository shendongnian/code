        class SexierSaveMethod
        {
            public Int32 Index { get; set; }
    
            public SexierSaveMethod(Int32 i)
            {
                Index = i;
            }
    
            public void AfterSaveMethod()
            { 
                // Use i here
            }
        }
        record.Save(new SexierSaveMethod(i).AfterSaveMethod);
