    finally {
        doc.Close(null, null, null);
        applicationWord.Quit();
        if (doc != null)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
        if (applicationWord != null)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(applicationWord);
        doc = null;
        applicationWord = null;
        GC.Collect(); // final cleanup    
    }
