    // loading bytes from a file is very easy in C#. The built in System.IO.File.ReadAll* methods take care of making sure every byte is read properly.
    byte[] bytes = System.IO.File.ReadAllBytes("myfile.pdf");
    // munge bytes with whatever pdf software you want
    // ...
    // make sure to cleanup after yourself
    // and save back - System.IO.File.WriteAll* makes sure all bytes are written properly.
    System.IO.File.WriteAllBytes("myfile.pdf", bytes);
