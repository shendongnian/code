    using(StreamReader sr = File.OpenText(HttpContext.Current.Server.MapPath(txt)))
    {
        copy = sr.ReadToEnd();
    } // reader is closed by the end of the using block
    
    //remove the word specified UC 
    copy = copy.Replace(word.ToUpper(), "#" + word.ToUpper());    
    
    //save new copy into existing text file 
    
    FileInfo newText = new FileInfo(HttpContext.Current.Server.MapPath(txt));
    
    using(var newCopy = newText.CreateText())
    {
        newCopy.WriteLine(copy);
        newCopy.Write(newCopy.NewLine);
    }
