        private void Form1_Load(object sender, EventArgs e)
        {
            Panel p = new Panel();        // added code    
            for (int row = 0; row < LinhaText; row++)
            {
                List<TextBox> newRow = new List<TextBox>();
                textboxes.Add(newRow);
                for (int col = 0; col < ColunText; col++)
                {
                    TextBox newbox = new TextBox();
                    newbox.Width = TEXTBOX_WIDTH;
                    newbox.Height = TEXTBOX_HEIGHT;
                    newbox.Top = (row * (TEXTBOX_HEIGHT + SPACING)) + SPACING;
                    newbox.Left = (col * (TEXTBOX_WIDTH + SPACING)) + SPACING;
                    newRow.Add(newbox);
                    p.Controls.Add(newbox);    // modified code (added textboxes to panel rather than form)
                }
            }
            // added code
            p.Dock = DockStyle.Fill;
            this.Controls.Add(p);
            this.Controls.SetChildIndex(p, 0);
            Button b1 = new Button();
            b1.Text = "hi";
            b1.Dock = DockStyle.Bottom;
            this.Controls.Add(b1);
            this.Controls.SetChildIndex(b1, 1);
        }
