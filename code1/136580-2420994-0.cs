     // Call the method 
        StatusError newErrorToAdd1 = new StatusError();
        newErrorToAdd1.ErrorNumber = "1112";
        newErrorToAdd1.ErrorMessage = "Demo error "; 
        transactionRequestOut = AddErrorToTransactionRequest(transactionRequestOut, newErrorToAdd1);
    public static TransactionRequest AddErrorToTransactionRequest(TransactionRequest transReq, StatusError newErr)
    {
            int intErrSubscript; 
            // If response is there use it, else add it 
            if (transReq.TransactionResponse == null)
            {
                TransactionResponse transactionResponse = new TransactionResponse();
                transReq.TransactionResponse = transactionResponse; 
            }
            // If response/errors are there, use them, else add them  
            if (transReq.TransactionResponse.Status == null)
            {
                Status status = new Status();
                transReq.TransactionResponse.Status = status; 
            }
            // If response/errors are there, use them, else add them  
            if (transReq.TransactionResponse.Status.Errors == null)
            {
                StatusError[] errors = new StatusError[1];
                errors[0] = new StatusError();
                intErrSubscript = 0;
                transReq.TransactionResponse.Status.Errors = errors;
            }
            else
            {
                int newArraySize = transReq.TransactionResponse.Status.Errors.Length + 1;
                intErrSubscript = newArraySize - 1;
                StatusError[] errors = transReq.TransactionResponse.Status.Errors;
                Array.Resize<StatusError> (ref errors,  newArraySize);
                transReq.TransactionResponse.Status.Errors = errors; 
            }
            transReq.TransactionResponse.Status.Errors[intErrSubscript] = newErr;
            return transReq; 
    }
