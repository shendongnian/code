     for (int i = this.Controls.Count - 1; i >= 0; i--)
                {
                    PictureBox control = this.Controls[i] as PictureBox;
                    if (control == null)
                        continue;
    
                    this.Controls.Remove(control);
                }
