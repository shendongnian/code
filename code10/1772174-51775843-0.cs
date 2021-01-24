    private void PostFile(string URL, string myFilePath)
    {
         // test for the file
         if (System.IO.File.Exists(myFilePath) == false)
             throw new System.IO.FileNotFoundException("Can't find " + myFilePath);
         
         // get the file
         var csvFile = System.IO.File.ReadAllBytes(myFilePath);
         
        // post the file to the server using the webclient
         using (System.Net.WebClient client = new System.Net.WebClient())
         {
            client.UploadData(URL, csvFile);
         }
    }
