    void BeginBulkProcessing()
    {
        DisbaleFooEventHandlers();
        ...
    }
    void OnBulkProcessingComplete()
    {
        ...
        EnableFooEventHandlers();
    }
