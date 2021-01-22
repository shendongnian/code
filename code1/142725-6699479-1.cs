        int _selIndex;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == _selIndex)
                return;
            if (MessageBox.Show("") == DialogResult.Cancel)
            {
                listBox1.SelectedIndex = _selIndex;
                return;
            }
            _selIndex = listBox1.SelectedIndex;
            // and the remaining part of the code, what needs to happen when selected index changed happens
        }
