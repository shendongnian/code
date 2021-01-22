        private void toolStrip1_Resize(object sender, EventArgs e) {
            toolStripComboBox1.Width = toolStripComboBox2.Bounds.Left - toolStripButton1.Bounds.Right - 4;
        }
        protected override void OnLoad(EventArgs e) {
            toolStrip1_Resize(this, e);
        }
