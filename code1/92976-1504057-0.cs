    public void SpellCheckControl(Control control )
    {
        foreach (Control ctrl in control.Controls)
        {
            SpellCheckControl(ctrl);
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
