    foreach(object key in h.keys)
    {
         string keyAsString = key.ToString(); // btw, this is unnecessary
         string valAsString = h[key].ToString();
    
         System.Diagnostics.Debug.WriteLine(keyAsString + " " + valAsString);
    }
