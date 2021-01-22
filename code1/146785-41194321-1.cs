		public static StatusStrip FixPadding(this StatusStrip ss) {
			if (!ss.SizingGrip) {
				var fixpad = ss.Padding;
				if (ss.Orientation == Orientation.Horizontal) {
					if (ss.RightToLeft == RightToLeft.No)
						fixpad.Right = fixpad.Left;
					else
						fixpad.Left = fixpad.Right;
				}
				else
					fixpad.Bottom = fixpad.Top;
				ss.Padding = fixpad;
			}
			return ss;
		}
		public static void FixStatusStripPadding(this Form f) {
			foreach (var ss in f.GetAllChildren().OfType<StatusStrip>())
				ss.FixPadding();
		}
