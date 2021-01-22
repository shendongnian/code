    bool success = false;
    try {
        reader = new StreamReader(path);
        success = true;
    }
    catch(Exception) {
        // Uh oh something went wrong with opening the file for reading
    }
    finally {
        if(success) {
            string line = reader.ReadLine();    
            char character = line[30];
        }
    }   
