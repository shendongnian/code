    while ((line = file.ReadLine()) != null) { 
        string messageDownloadID = line;
        if (String.IsNullOrEmpty(messageDownloadID)) { 
            continue; 
        }
        ProcessMessageDownloadID(messageDownloadID);
    }
