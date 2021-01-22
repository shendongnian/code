        //These functions prevent the textboxes from being implicitly selected.
        private void dummyBox_Leave(object sender, EventArgs e)
        {
            dummyBox.TabStop = false;
        }
        private void Main_Enter(object sender, EventArgs e)
        {
            dummyBox.TabStop = true;
            dummyBox.Select();
        }
