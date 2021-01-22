    // loading bytes from a file is very easy in C#
    byte[] bytes = System.IO.File.ReadAllBytes("myfile.pdf");
    // munge bytes with whatever pdf software you want
    // ...
    // make sure to cleanup after yourself
    // and save back
    System.IO.File.WriteAllBytes("myfile.pdf", bytes);
