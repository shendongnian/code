        //using System;
        //using System.Collections.Generic;
        //using System.Linq;
        private void Form1_Load(object sender, EventArgs e)
        {
            FocusOnOtherControl(Controls.Cast<Control>(), button1);
        }
        private void FocusOnOtherControl<T>(IEnumerable<T> controls, Control focusOnMe) where T : Control
        {
            foreach (var control in controls)
            {
                if (control.GetType().Equals(typeof(TextBox)))
                {
                    control.TabStop = false;
                    control.LostFocus += new EventHandler((object sender, EventArgs e) =>
                    {                     
                        focusOnMe.Focus();
                    });
                }
            }
        }
