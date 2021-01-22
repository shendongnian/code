    //Global variables
    long gTotalDownloadedBytes;
    long gCurrentDownloaded; // Where you add up from the download/upload untill the speedcheck is done.
    int gTotalDownloadSpeedChecks;//Inside function
    
    gTotalDownloadedBytes += gCurrentDownloaded;
    gTotalDownloadSpeedChecks++;
    
    long AvgDwnSpeed = gTotalDownloadedBytes / gTotalDownloadSpeedChecks; // Assumes 1 speedcheck pr second.
