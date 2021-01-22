      enum position
        {
            Left,Right,up,down
        }
        private int _x;
        private int _y;
        private position _objposition;
        public Form1()
        {
            InitializeComponent();
            _x = 50;
            _y = 50;
            _objposition = position.down;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkSlateBlue,_x,_y,100,100);
        }
        private void timertick_Tick(object sender, EventArgs e)
        {
            if (_objposition == position.Right)
            {
                _x += 10;
            }
            else if (_objposition == position.Left)
            {
                _x -= 10;
            }
            else if (_objposition == position.up)
            {
                _y -= 10;
            }
            else if (_objposition == position.down)
            {
                _y += 10;
            }
            Invalidate();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                _objposition =position.Left;
            }
            else if (e.KeyCode == Keys.Right)
            {
                _objposition = position.Right;
            }
            else if (e.KeyCode == Keys.Up)
            {
                _objposition = position.up;
            }
            else if (e.KeyCode == Keys.Down)
            {
                _objposition = position.down;
            }
        }
    }
