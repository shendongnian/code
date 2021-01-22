    Job j = obj as job;
    if (j != null)
    {
        Debug.WriteLine(j.Title);
    }
    else
    {
        Place p = obj as Place;
        if (p != null)
        {
            Debug.WriteLine(p.Title);
        }
    }
