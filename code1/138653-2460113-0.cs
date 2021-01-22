       var localWordapp = new Word.Application();
       localWordapp.Visible = false;
       Word.Document doc = null;
       // ...
        if (doc != null)
        {
          doc.Close();
          System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
        }
        localWordapp.Quit();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(localWordapp);
