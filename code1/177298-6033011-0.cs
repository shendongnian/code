        public void InitDriveDetector()
        {
            this.dd = new DriveDetector(); // create the drive detector
            // add new event handlers
            dd.DeviceArrived += new DriveDetectorEventHandler(dd_DeviceArrived);
            dd.DeviceRemoved += new DriveDetectorEventHandler(dd_DeviceRemoved);
        }
        void dd_DeviceRemoved(object sender, DriveDetectorEventArgs e)
        {
            Debug.WriteLine("{0} removed",e.Drive);
            //Will output something like "H:\ removed"
        }
        void dd_DeviceArrived(object sender, DriveDetectorEventArgs e)
        {
            Debug.WriteLine("{0} arrived",e.Drive);
            //Will output something like "H:\ removed"
        }
