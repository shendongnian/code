    switch(error) {
        case SQLErrorCode.PARTIAL_OK: 
        case SQLErrorCode.SOMEWHAT_OK:
        case SQLErrorCode.NOT_OK: 
             callFunction1();
             break;
        case SQLErrorCode.OK:
             callFunction2();
             break;
        default:
             if (error < 0)
                  callFunction1();
             else
                  callFunction2();
             break;
    }
