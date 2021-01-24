            string message = "Some diagnostic message";
            if ((bool)this.Dts.Variables["System::InteractiveMode"].Value)
            {
                MessageBox.Show(message);
            }
