    Object operationResult;
    try {
      operationResult = remoteService.performRemoteOperation();
    } catch (RemoteException ex) {
      throw new BusinessException("An error occured when getting ...", ex);
    }
    
    // use operation result
