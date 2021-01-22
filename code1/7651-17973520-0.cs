	public partial class NumberedTextBox : UserControl
	{
		private int _lines = 0;
		[Browsable(true), 
			EditorAttribute("System.ComponentModel.Design.MultilineStringEditor, System.Design","System.Drawing.Design.UITypeEditor")]
		new public String Text
		{
			get
			{
				return editBox.Text;
			}
			set
			{
				editBox.Text = value;
				Invalidate();
			}
		}
		private Color _lineNumberColor = Color.LightSeaGreen;
		
		[Browsable(true), DefaultValue(typeof(Color), "LightSeaGreen")]
		public Color LineNumberColor {
			get{
				return _lineNumberColor;
			}
			set
			{
				_lineNumberColor = value;
				Invalidate();
			}
		}
		public NumberedTextBox()
		{
			InitializeComponent();
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			editBox.SelectionChanged += new EventHandler(selectionChanged);
			editBox.VScroll += new EventHandler(OnVScroll);
		}
		private void selectionChanged(object sender, EventArgs args)
		{
			Invalidate();
		}
		private void DrawLines(Graphics g)
		{
			g.Clear(BackColor);
			int y = - editBox.ScrollPos.Y;
			for (var i = 1; i < _lines + 1; i++)
			{
				var size = g.MeasureString(i.ToString(), Font);
				g.DrawString(i.ToString(), Font, new SolidBrush(LineNumberColor), new Point(3, y));
				y += Font.Height + 2;
			}
			var max = (int)g.MeasureString((_lines + 1).ToString(), Font).Width + 6;
			editBox.Location = new Point(max, 0);
			editBox.Size = new Size(ClientRectangle.Width - max, ClientRectangle.Height);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			_lines = editBox.Lines.Count();
			DrawLines(e.Graphics);
			e.Graphics.TranslateTransform(50, 0);
			editBox.Invalidate();
			base.OnPaint(e);
		}
		private void OnVScroll(object sender, EventArgs e)
		{
			Invalidate();
		}
		public void Select(int start, int length)
		{
			editBox.Select(start, length);
		}
		public void ScrollToCaret()
		{
			editBox.ScrollToCaret();
		}
		private void editBox_TextChanged(object sender, EventArgs e)
		{
			Invalidate();
		}
	}
	public class RichTextBoxEx : System.Windows.Forms.RichTextBox
	{
		private double _Yfactor = 1.0d;
		
		[DllImport("user32.dll")]
		static extern IntPtr SendMessage(IntPtr hWnd, Int32 wMsg, Int32 wParam, ref Point lParam);
		private enum WindowsMessages
		{
			WM_USER = 0x400,
			EM_GETSCROLLPOS = WM_USER + 221,
			EM_SETSCROLLPOS = WM_USER + 222
		}
		public Point ScrollPos
		{
			get
			{
				var scrollPoint = new Point();
				SendMessage(this.Handle, (int)WindowsMessages.EM_GETSCROLLPOS, 0, ref scrollPoint);
				return scrollPoint;
			}
			set
			{
				var original = value;
				if (original.Y < 0)
					original.Y = 0;
				if (original.X < 0)
					original.X = 0;
				var factored = value;
				factored.Y = (int)((double)original.Y * _Yfactor);
				var result = value;
				SendMessage(this.Handle, (int)WindowsMessages.EM_SETSCROLLPOS, 0, ref factored);
				SendMessage(this.Handle, (int)WindowsMessages.EM_GETSCROLLPOS, 0, ref result);
				var loopcount = 0;
				var maxloop = 100;
				while (result.Y != original.Y)
				{
					// Adjust the input.
					if (result.Y > original.Y)
						factored.Y -= (result.Y - original.Y) / 2 - 1;
					else if (result.Y < original.Y)
						factored.Y += (original.Y - result.Y) / 2 + 1;
					// test the new input.
					SendMessage(this.Handle, (int)WindowsMessages.EM_SETSCROLLPOS, 0, ref factored);
					SendMessage(this.Handle, (int)WindowsMessages.EM_GETSCROLLPOS, 0, ref result);
					// save new factor, test for exit.
					loopcount++;
					if (loopcount >= maxloop || result.Y == original.Y)
					{
						_Yfactor = (double)factored.Y / (double)original.Y;
						break;
					}
				}
			}
		}
	}
