        using System;
    using static Android.Hardware.Camera;
    
    namespace Hangover.Droid.CameraCallbacks
    {
        public class ShutterCameraCallback : Java.Lang.Object, IShutterCallback
        {
            public void OnShutter()
            {
                Console.Write("shutter");
            }
        }
    }
