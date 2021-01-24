	public partial class MyCustomImageView : NSImageView
	{
		[Export("initWithCoder:")]
		public MyCustomImageView(NSCoder coder) : base(coder) { }
		public MyCustomImageView (IntPtr handle) : base (handle) { }
		NSCursor cursor;
		[Export("mouseEntered:")]
		public override void MouseEntered(NSEvent theEvent)
		{
			cursor = NSCursor.ClosedHandCursor;
			cursor.Push();
			base.MouseEntered(theEvent);
		}
		[Export("mouseExisted:")]
		public override void MouseExited(NSEvent theEvent)
		{
			base.MouseExited(theEvent);
			cursor?.Pop();
		}
	}
