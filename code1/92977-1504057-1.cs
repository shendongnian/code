    public void SpellCheckControl(Control control, int depth)
    {
        if(depth > 0)
        {
            if(Control.HasChildren())
            {
                foreach (Control ctrl in control.Controls)
                {
                    SpellCheckControl(ctrl, depth - 1);
                }
            }
        }
                    
        if (control.GetType() == typeof(MemoExEdit))
        {
            if (control.Text != String.Empty)
            {
                control.BackColor = Color.FromArgb(180, 215, 195);
                control.Text = HUD.Spelling.CheckSpelling(control.Text);
                control.ResetBackColor();
            }
        }
    }
