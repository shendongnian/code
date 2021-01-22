        protected override void OnMouseMove(MouseEventArgs e)
        {
            Control c = this.GetChildAtPoint(e.Location);
            if (c != null)
            {
                MessageBox.Show(String.Format("Your control name is: {0} and type is {1}.", c.Name, c.GetType().ToString()));
            }
            base.OnMouseMove(e);
        }
