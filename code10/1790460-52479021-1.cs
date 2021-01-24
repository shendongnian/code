        private void MakeControlsInvisible(Control container, params Type[] controlTypes)
        {
            foreach (Control control in container.Controls)
            {
                if (controlTypes.Contains(control.GetType()))
                {
                    control.Visible = false;
                }
                if (control.Controls.Count > 0)
                {
                    MakeControlsInvisible(control, controlTypes);
                }
            }
        }
