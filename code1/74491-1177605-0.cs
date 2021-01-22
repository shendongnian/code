    try {
        reader = new StreamReader(path);
    }
    catch(Exception ex) {
        // Uh oh something went wrong with opening the file stream
        MyOpeningFileStreamException newEx = new MyOpeningFileStreamException();
        newEx.InnerException = ex;
        throw(newEx);
    }
        string line = reader.ReadLine();
        char character = line[30];
