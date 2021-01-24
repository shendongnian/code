        public void ChildControl_MouseDown ( object sender, MouseEventArgs e ) {
            if ( e.Button == MouseButtons.Right ) {
                MessageBox.Show ( "Huzzah!" );
            }
            if ( e.Button == MouseButtons.Left ) {
                //MessageBox.Show ( "Booyah!" );
                this.OnMouseDown ( e );
            }
        }
        public void ChildControl_MouseMove ( object sender, MouseEventArgs e ) {
            if ( e.Button == MouseButtons.Left ) {
                this.OnMouseMove ( e );
            }
        }
        public void ChildControl_MouseUp ( object sender, MouseEventArgs e ) {
            if ( e.Button == MouseButtons.Left ) {
                this.OnMouseUp ( e );
            }
        }
