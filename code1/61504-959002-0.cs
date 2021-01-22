    for (int i = 0; i < FirstNames.Count; i++)
    {
        CRObject cr = new CRObject();
        cr.Firstname = (string)FirstNames[i];
        cr.Lastname = (string)LastNames[i];
        if (FirstNames.Count > 1)
        {
            cr.Tif = baseTif + increment.ToString();
            increment++;
        }
        CaseRecordItems.Add(cr);
    }
