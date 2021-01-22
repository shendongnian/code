    // loading bytes from a file is very easy in C#. The built in System.IO.File.ReadAll* methods take care of making sure every byte is read properly.
    // note that for Linux, you will not need the c: part
    // just swap out the example folder here with your actual full file path
    string pdfFilePath = "c:/pdfdocuments/myfile.pdf";
    byte[] bytes = System.IO.File.ReadAllBytes(pdfFilePath);
    // munge bytes with whatever pdf software you want, i.e. http://sourceforge.net/projects/itextsharp/
    // bytes = MungePdfBytes(bytes); // MungePdfBytes is your custom method to change the PDF data
    // ...
    // make sure to cleanup after yourself
    // and save back - System.IO.File.WriteAll* makes sure all bytes are written properly.
    System.IO.File.WriteAllBytes(pdfFilePath, bytes);
