    ...
    void Start()
    {
        ...
        data = new Color32[webcamTexture.width * webcamTexture.height];
        ...
    }
    ...
    void FixedUpdate ()
    {
        ...
        webCamTexture.GetPixels32(data); //this is faster than returning a Color32 object
        ...
    } 
    ...
    private void runPython(string pathToPythonExecutable, string pyTorchScript, Color32[] data)
    {
         var startInfo = new ProcessStartInfo();
         var pyTorchArgs = convertDataToYourPyTorchInputFormat (data)
         startInfo.Arguments = string.Format("{0} {1}", pyTorchScript, pyTorchArgs);
         startInfo.FileName = pathToPythonExecutable;
         startInfo.UseShellExecute = false;
         var process = Process.Start(start));
         process.WaitForExit();
         //do stuff in unity with the return value of process (process.ExitCode) or whatever.
    }
