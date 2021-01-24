    public override bool ValidateChildren()
            {
                bool allValid = true;
                foreach (Control control in this.Controls)
                {
                    if (control.Name == "Id")
                    {
                        continue;
                    }
    
                    if (!control.IsValid())
                    {
                        allValid = false;
                    }
                }
                return allValid;
            }
    public static bool IsValid(this Control controlToValidate)
            {
                Debug.Assert(controlToValidate != null, "Control to validate is null");
    
                Type t = typeof(Control);
    
    
                MethodInfo mi = t.GetMethod("NotifyValidating", BindingFlags.Instance |
                                                                BindingFlags.NonPublic | BindingFlags.InvokeMethod);
    
                Debug.Assert(mi != null, "Could not get method information.");
                    
                return !((Boolean)mi.Invoke(controlToValidate, null));
    
            }
