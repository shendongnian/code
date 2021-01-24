            //...
        }
        private double m_x = 0.0;
        private double m_y = 0.0;
        private void StackPanel_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var p = e.GetPosition(this);
            m_x = p.X;
            m_y = p.Y;
        }
        private void StackPanel_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Space) {
                DoMouseClick(m_x, m_y);
            }
        }
