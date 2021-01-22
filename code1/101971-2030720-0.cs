    static void Main( string[] args )
    {
        var job = new Microsoft.Expression.Encoder.Live.LiveJob();
        job.AddDeviceSource( job.VideoDevices[0],job.AudioDevices[0] );
        var w = new System.Windows.Forms.Form();
        w.Show();
        var source = job.DeviceSources[0];
        source.PreviewWindow = new Microsoft.Expression.Encoder.Live.PreviewWindow( new System.Runtime.InteropServices.HandleRef(w, w.Handle) );
        Console.ReadKey();
    }
