        private void ToggleActivationOfControls(Control ContainingControl, Boolean ControlIsEnabled)
        {
            try
            {
                foreach (Control ctrl in ContainingControl.Controls)
                {
                    if (ctrl.GetType() == typeof(Button))
                    { 
                        ctrl.Enabled = ControlIsEnabled;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Error occurred during ToggleActivationOfControls");
               
            }
        }
