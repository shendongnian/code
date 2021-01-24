    await files.ToList().ForEachAsync(async i => {
        await ReadStream(i);
    });
    
    void ReadStream(File file){
        using (StreamReader fr = new StreamReader(file))
        {
            string lr;
        
            while ((lr = fr.ReadLine()) != null)
            {
                Match m1_1 = m1.Match(lr);
                Match m2_2 = storageSize.Match(lr);
                Match m3_3 = logStart.Match(lr);
                Match m4_4 = mergeStart.Match(lr);
                Match m5_5 = filePatcher.Match(lr);
                Match m6_6 = mergeEnd.Match(lr);
                Match m7_7 = logEnd.Match(lr);
        
                if (m1_1.Success)
                {
                    string m1_str = m1_1.Value;
                    //do stuff
                }
                if (m2_2.Success)
                {
                     string m2_str = m2_2.Value;
                     //do stuff
                }
        
            }
        }
    }
