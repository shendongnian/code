        using (Graphics g = CreateGraphics()) {
            g.Clear(this.BackColor);                <=== added
            g.SetClip(ClientRectangle);
            // etc..
        }
