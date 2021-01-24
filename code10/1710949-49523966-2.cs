    if (rp.Available)
    {
    	// TODO: Also note that we are not using the Async version here
    	rp.StartCapture((buffer, sampleType, error) =>
        {
    		try {
    			if (buffer.DataIsReady) {
    
    				if (assetWriter.Status == AVAssetWriterStatus.Unknown) {
    
    					assetWriter.StartWriting ();
    
    					assetWriter.StartSessionAtSourceTime (buffer.PresentationTimeStamp);
    
    				}
    
    				if (assetWriter.Status == AVAssetWriterStatus.Failed) {
    					return;
    				}
    
    				if (sampleType == RPSampleBufferType.Video) {
    					if (videoInput.ReadyForMoreMediaData) {
    						videoInput.AppendSampleBuffer (buffer);
    					}
    				}
    
    			}
    		} finally {
    			buffer.Dispose ();
    		}
            
    
        }, null);
    }
