    Word.Range rng = null;
    
    foreach (para In doc.Paragraphs)
    {
        rng = para.Range;
        foreach (fld In rng.Fields)
        {
            if (fld.Type = Word.WdFieldType.wdFieldRef)
            {
                Debug.Print("Code: " + fld.Code.Text + "; Result: " + fld.Result.Text);
            }
        }
    }
