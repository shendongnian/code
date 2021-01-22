        private void ToggleControls()
        {
                 Foo(this.Controls, false) // this being the form, of course.
        }
        private void Foo(Control.ControlCollection controls, bool enabled)
        {
            foreach (Control c in controls)
            {
                if (c is Button && c.Tag != null)
                    c.Enabled = enabled;
                if (c.HasChildren)
                    Foo(c.Controls, enabled);
            }
        }
