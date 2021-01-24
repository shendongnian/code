                this.BackColor = Control.DefaultBackColor;
            foreach (Control c in this.Controls)
            {
                if (c is Button b)
                {
                    b.BackColor = Control.DefaultBackColor;
                    b.UseVisualStyleBackColor = true;
                }
            }
