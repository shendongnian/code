    var sb = new System.Text.StringBuilder();
    sb.Append("This is the text file...");
    foreach (var item in listOfStrings)
        sb.Append(item);
    
    // sb now contains all the content that will be placed into
    // the text file entry inside the zip.
    using (var zip = new Ionic.Zip.ZipFile())
    {
        // set the password on the zip (implicitly enables encryption)
        zip.Password = "Whatever.You.Like!!"; 
        // optional: select strong encryption
        zip.Encryption = Ionic.Zip.EncryptionAlgorithm.WinZipAes256;
        // add an entry to the zip, specify a name, specify string content
        zip.AddEntry("NameOfFile.txt", sb.ToString());
        // save the file
        zip.Save("MyFile.zip");
    }
