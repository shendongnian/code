        public bool m_right = false;
        public bool m_left = false;
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            m_objGraphics.Clear(SystemColors.Control);
            if (e.Button == MouseButtons.Left)
                m_left = true;
            if (e.Button == MouseButtons.Right)
                m_right = true;
            
            if (m_left == false || m_right == false) return;
            //do something here
        }
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                m_left = false;
            if (e.Button == MouseButtons.Right)
                m_right = false;
         }
