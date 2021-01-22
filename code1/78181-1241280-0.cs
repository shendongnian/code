    switch(error){
       case SQLErrorCode.PARTIAL_OK: 
        case SQLErrorCode.SOMEWHAT_OK:
        case SQLErrorCode.NOT_OK: 
                                    callFunction1();
                                    break;
        default:
                                    callFunction2();
                                    break;
}
