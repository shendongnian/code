        string originalFileName;
        using (CameraCaptureDialog dlg = new CameraCaptureDialog()) {
            dlg.Mode = CameraCaptureMode.Still;
            dlg.StillQuality = CameraCaptureStillQuality.Low;
            //dlg.Resolution = new Size(800, 600);
            dlg.Title = "Take the picture";
            DialogResult res;
            try {
                res = dlg.ShowDialog();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex);
                return null;
            }
        
            if (res != DialogResult.OK)
                return null;
            this.Refresh();
            originalFileName = pictureFileName = dlg.FileName;
        }
