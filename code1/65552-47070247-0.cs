    //FSm is stream for creating file on a path//
    System.IO.FileStream FS = new System.IO.FileStream(path + fname,
                                                       System.IO.FileMode.Create);
    pro.CopyTo(FS);
    FS.Dispose();
