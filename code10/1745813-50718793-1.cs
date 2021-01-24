    public class MoveLabel : Label
    {
        public Form1.Moved MoveAction { get; set; }
        public int PointIndex { get; set; }
        private Point mDown = Point.Empty;
        public MoveLabel()
        {
            MouseDown += (ss, ee) => { mDown = ee.Location; };
            MouseMove += (ss, ee) => {
                if (ee.Button.HasFlag(MouseButtons.Left))
                {
                    Location = new Point(Left + ee.X - Width / 2, Top + ee.Y - Height / 2);
                    mDown = Location;
                }
            };
            MouseUp += (ss, ee) => { MoveAction(this);  };
        }
        public MoveLabel(Color c, int size, Point location) : this()
        {
            BackColor = Color.CadetBlue;
            Size = new Size(size, size);
            Location = location;
        }
        public MoveLabel(Color c, int size, Point location, int pointIndex) : this()
        {
            BackColor = Color.CadetBlue;
            Size = new Size(size, size);
            Location = location;
            PointIndex = pointIndex;
        }
    }
