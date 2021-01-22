    public class CProgressBar : ProgressBar
    {
	public Color MyColor {
		get { return _color; }
		set {
			_color = value;
			MyBrush = new SolidBrush(_color);
			Invalidate();
		}
	}
	private Color _color = Color.Green;
	
    public CProgressBar()
	{
		SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
	}
	public int Value {
		get { return _value; }
		set {
			_value = value;
			Invalidate();
		}
	}
	private int _value;
	private SolidBrush MyBrush = new SolidBrush(_color);
	
    protected override void OnPaint(PaintEventArgs e)
	{
		e.Graphics.FillRectangle(MyBrush, new Rectangle(0, 0, Width * (_value / Maximum), Height));
	}
    }
