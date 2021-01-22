    class MouseDragger
    {
        private readonly Form _form;
        private Point _mouseDown;
        protected void OnMouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = e.Location;
        }
        protected void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = e.Location.X - _mouseDown.X;
                int dy = e.Location.Y - _mouseDown.Y;
                _form.Location = new Point(_form.Location.X + dx, _form.Location.Y + dy);
            }
        }
        public MouseDragger(Form form)
        {
            _form = form;
            MakeDraggable(_form);            
        }
        private void MakeDraggable(Control control)
        {
            var type = control.GetType();
            if (typeof(Button).IsAssignableFrom(type))
            {
                return;
            }
            control.MouseDown += OnMouseDown;
            control.MouseMove += OnMouseMove;
            foreach (Control child in control.Controls)
            {
                MakeDraggable(child);
            }
        }
    }
