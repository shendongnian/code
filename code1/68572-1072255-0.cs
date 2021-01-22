            Microsoft.VisualBasic.Devices.Network net = new Microsoft.VisualBasic.Devices.Network();
            if (net.IsAvailable)
            {
                Text = "Network is available";
            }
            else
            {
                Text = "Network unavailable";
            }
