    unsigned long QueryDeviceInfo(
         unsigned long deviceIndex
       , unsigned long *pPID
       , unsigned long *pNameSize
       , char *pName
       , unsigned long *pDIOBytes
       , unsigned long *pCounters
       )
    {
       *pPID = 9;
       *pDIOBytes = 8;
       *pCounters = 7;
       *pNameSize = 6;
       return 0;
    }
