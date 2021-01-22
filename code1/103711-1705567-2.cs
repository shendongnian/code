    public static class KeyHandler
    {
        public static void NextTabHandler(Form theCallingForm)
        {
            Console.WriteLine("called from : " + theCallingForm.Text + " : ActiveControl : " + theCallingForm.ActiveControl.Name);
    
            if (theCallingForm is MDIForm)
            {
                // handle Next Tab on MDIForm control
            }
            else if (theCallingForm is childForm)
            {
                // handle Next Tab on ChildForm control
            }
            else
            {
                if(theCallingForm is independentForm)
                {
                    // handle Next Tab on "independent Form" control
                }
            }
        }
    }
