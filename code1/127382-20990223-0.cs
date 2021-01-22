        private class ToolTipWPFWindow : Window
        {
            private readonly TextBlock m_txtToDisplay = new TextBlock();
            private readonly DispatcherTimer m_timer = new DispatcherTimer();
            public ToolTipWindow(string p_strStringToDisplay, int p_intXOnScreen = 0, int p_intYOnScreen = 0, double p_dblDurationInMilliSeconds = 1500)
            {
                if (p_intXOnScreen == 0 && p_intYOnScreen == 0)
                {
                    p_intXOnScreen = System.Windows.Forms.Cursor.Position.X;
                    p_intYOnScreen = System.Windows.Forms.Cursor.Position.Y;
                }
                m_txtToDisplay.Text = p_strStringToDisplay;
                m_txtToDisplay.Margin = new Thickness(3);
                Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
                ShowInTaskbar = false;
                ResizeMode = System.Windows.ResizeMode.NoResize;
                Topmost = true;
                // Location on screen - As Set
                WindowStartupLocation = WindowStartupLocation.Manual;
                Left = p_intXOnScreen;
                Top = p_intYOnScreen;
                WindowStyle = WindowStyle.None;
                SizeToContent = SizeToContent.WidthAndHeight;
                Content = m_txtToDisplay;
                m_timer.Interval = TimeSpan.FromMilliseconds(p_dblDurationInMilliSeconds);
                m_timer.Tick += timer_Tick;
                m_timer.Start();
            }
            private void timer_Tick(object sender, EventArgs e)
            {
                if (m_timer != null)
                {
                    m_timer.Stop();
                    m_timer.Tick -= timer_Tick;
                }
                
                Close();
            }
