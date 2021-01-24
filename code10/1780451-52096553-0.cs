        SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(OnPowerModeChanged);
        
        private static void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    MessageBox.Show("PowerMode: OS is resuming from suspended state");
                    break;
                case PowerModes.Suspend:
                    MessageBox.Show("PowerMode: OS is about to be suspended");
                    break;
            }
        }
