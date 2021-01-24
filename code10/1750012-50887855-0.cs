    public void ControlClear(Control controls,Type type)
            {
                foreach (Control c in controls.Controls)
                {
                    if (c.GetType() == type)
                    {
                        MessageBox.Show("true"); // Do whatever you want here. Since not all controls have Clear() method, consider using Text=string.Empty; or any other method to clear the selected type.
                    }
                    else
                    {
                        ControlClear(c, type); // fire the method to check if the control is a container and has another type you are targeting.
                    }
                   
                }
                   
            }
