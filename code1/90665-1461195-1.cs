	class FadeForm
	{
		readonly Form _top;
		readonly Timer _timer;
		readonly TimeSpan _delayToFade;
		readonly double _fadeAmount;
		Control _lastControl;
		DateTime _lastActivity;
		public FadeForm(Form ctrl, TimeSpan delayToFade, TimeSpan delaySpeed, double fadeAmount)
		{
			_top = ctrl;
			_delayToFade = delayToFade;
			_fadeAmount = fadeAmount;
			_lastActivity = DateTime.Now;
			WatchControl(_top);
			_timer = new Timer();
			_timer.Interval = (int)delaySpeed.TotalMilliseconds;
			_timer.Enabled = true;
			_timer.Tick += new EventHandler(Tick);
		}
		void  Tick(object sender, EventArgs e)
		{
			if (_lastControl != null || (DateTime.Now - _lastActivity) < _delayToFade)
			{
				if (_top.Opacity != 1)
					_top.Opacity = 1;
			}
			else
			{
				double newvalue = _top.Opacity -= _fadeAmount;
				if (newvalue > 0.0)
					_top.Opacity = newvalue;
				else
					_top.Close();
			}
		}
		void WatchControl(Control c)
		{
			c.MouseEnter += new EventHandler(MouseEnter);
			c.MouseLeave += new EventHandler(MouseLeave);
		}
		void MouseEnter(object sender, EventArgs e)
		{
			_lastControl = sender as Control;
		}
		void MouseLeave(object sender, EventArgs e)
		{
			_lastControl = null;
			_lastActivity = DateTime.Now;
		}
	}
