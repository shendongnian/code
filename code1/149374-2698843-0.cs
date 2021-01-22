        Rectangle BoundRect;
        Rectangle OldRect = Rectangle.Empty;
        private void EnableMouse()
        {
            Cursor.Clip = OldRect;
            Cursor.Show();
            Application.RemoveMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x201 || m.Msg == 0x202 || m.Msg == 0x203) return true;
            if (m.Msg == 0x204 || m.Msg == 0x205 || m.Msg == 0x206) return true;
            return false;
        }
        private void DisableMouse()
        {
            OldRect = Cursor.Clip;
            // Arbitrary location.
            BoundRect = new Rectangle(50, 50, 1, 1); 
            Cursor.Clip = BoundRect;
            Cursor.Hide();
            Application.AddMessageFilter(this);
        }  
