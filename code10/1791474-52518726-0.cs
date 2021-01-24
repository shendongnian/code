    using System;
    using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
    using Microsoft.WindowsAPICodePack.Shell;
    using System.Diagnostics;
    
    class Program {
        void getProperty() {
            var cameraModel = GetValue(picture.Properties.
            GetProperty(SystemProperties.System.Photo.CameraModel));
        }
    }
