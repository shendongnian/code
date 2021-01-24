    var jobIdArray = new List<string>();
    jobIdArray.Add(doc.FieldValues(x => x.JobId).FirstOrDefault());
    for (int i = 0; i < jobIdArray; i += 15000)
    {
        var fileLoc = @"F:\WindowsApplication" + new Guid() + ".txt";
        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileLoc))
        {
            for (int x = i; x < 15000; i++)
            {
                if (!String.IsNullOrEmpty(jobIdArray[x]))
                {
                    sw.WriteLine(jobIdArray[x]);
                }
            }
        }
    }
