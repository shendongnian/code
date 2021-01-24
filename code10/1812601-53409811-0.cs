    static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
    public static string Process(Bitmap image)
    {
       ...
       int result = ocEngine.ReadImage(image);
       autoResetEvent.WaitOne(2500);
       ...
    }
