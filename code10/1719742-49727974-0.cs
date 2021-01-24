    public Cursor HitTestGuide(Point p, RulerOrientation mode)
		{
			if (_Guides.Exists(g => (int)g.Info.Orientation == (int)mode && g.HitTest(p)))
			{
				return _Guides.First(g => (int)g.Info.Orientation == (int)mode && g.HitTest(p)).Cursor;
			}
			return Cursors.Arrow;
		}
