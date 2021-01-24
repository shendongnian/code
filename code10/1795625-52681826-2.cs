    using System;
    using Android.Hardware;
    using Java.Lang;
    using static Android.Hardware.Camera;
    
    namespace Hangover.Droid.CameraCallbacks
    {
        public class RawCameraCallback : Java.Lang.Object ,IPictureCallback 
        {
    
            public void OnPictureTaken(byte[] data, Android.Hardware.Camera camera)
            {
                Console.Write("raw data");
                Console.Write(data);
            }
        }
    }
