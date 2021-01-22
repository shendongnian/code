        private void SetText(ControlCollection controls, String textToSet)
        {
            foreach(Control c in controls)
            {
                if (c is ITextControl)
                    ((ITextControl)c).Text = textToSet;
                if (c.HasControls())
                    SetText(c.Controls, textToSet);
            }
        }
