    void OnEnable()
    {
        RenderPipeline.beginCameraRendering += BeginCameraRendering;
        RenderPipeline.beginFrameRendering += BeginFrameRendering;
    }
    
    void OnDisable()
    {
        RenderPipeline.beginCameraRendering -= BeginCameraRendering;
        RenderPipeline.beginFrameRendering -= BeginFrameRendering;
    }
    
    void BeginCameraRendering(Camera camera)
    {
    
    }
    
    void BeginFrameRendering(Camera[] cameras)
    {
    
    }
