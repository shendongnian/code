        private void btnSample_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.Cross;
        }
        protected override void OnMouseDown(MouseEventArgs e) {
            if (this.Cursor == Cursors.Cross) {
                this.Cursor = Cursors.Default;
                // etc...
            }
        }
