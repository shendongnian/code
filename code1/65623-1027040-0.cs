        private void dateTimePicker1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0) System.Windows.Forms.SendKeys.Send("{UP}");
            else System.Windows.Forms.SendKeys.Send("{DOWN}");
        }
