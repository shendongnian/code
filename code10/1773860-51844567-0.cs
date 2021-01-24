    foreach (Word.Footnote ftn in document.Footnotes)
    {
        foreach (Word.Field fld in ftn.Range.Fields)
        {
            System.Diagnostics.Debug.Print(fld.Code.Text + ", " + fld.Result.Text);
        }
    }
