    void WalkControls(Control root)
            {
                if (root == null ) return;
                foreach (Control control in root.Controls)
                {
                    if (control is ISpellCheckable)
                    {
                        if (((ISpellCheckable)control).SpellCheck())
                        {
                            // do stuff
                        }
                    }
                    WalkControls(control);
                }
            }
