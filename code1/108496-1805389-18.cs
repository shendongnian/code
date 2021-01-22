    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    private static EventHandler _event;
        // extension method on Control.ControlCollection
        public static void SetEnterEvent(this Control.ControlCollection theCollection, EventHandler theEvent)
        {
            _event = theEvent;
            recurseSetEnter(theCollection);
        }
        // recurse all the controls and add the Enter Event :
        public static void recurseSetEnter(Control.ControlCollection aCollection)
        {
            foreach (Control theControl in aCollection)
            {
                // "weed out" things like internal controls of the NumericUpDown Control
                // String.IsNullOrWhiteSpace is FrameWork 4.0
                // use Trim() followed by String.IsNullOrEmpty for FrameWork 3.5
                if (!String.IsNullOrWhiteSpace(theControl.Name))
                {
                    Console.WriteLine("setting enter handler for : " + theControl.Name + " : " + theControl.GetType().ToString() + " is container = " + (theControl is IContainerControl).ToString());
                        
                    theControl.Enter += _event;
                }
                if (theControl.Controls.Count > 0) recurseSetEnter((Control.ControlCollection)theControl.Controls);
            }
        }
