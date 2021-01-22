        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Am I allowed to close
            if (_vetoClosing)
            {
                _vetoClosing = false;
                e.Cancel = true;
            }
        }
