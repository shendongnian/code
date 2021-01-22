    if (null != col)
    {
        NotesDocument doc = col.GetFirstDocument();
        while (doc != null)
        {
            //do your magic tricks
            doc = col.GetNextDocument(doc);
        }
    }    
    
