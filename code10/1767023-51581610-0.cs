    private void Form7_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Space)
            {
                IEyeTracker eyeTracker = EyeTrackingOperations.FindAllEyeTrackers().FirstOrDefault();
                GazeDataStop(eyeTracker);
            }
        }
