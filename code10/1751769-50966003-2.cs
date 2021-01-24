    [assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]
    namespace TestApp.Droid
    {
    public class RoundedBoxViewRenderer : BoxRenderer
	{
		public RoundedBoxViewRenderer(Context context) : base(context)
		{
		}
		protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
		{
			base.OnElementChanged(e);
			SetWillNotDraw(false);
			Invalidate();
		}
		public override void Draw(Canvas canvas)
		{
			var box = Element as RoundedBoxView;
			var rect = new Rect();
			var paint = new Paint()
			{
				Color = box.BackgroundColor.ToAndroid(),
				AntiAlias = true,
			};
			GetDrawingRect(rect);
			var radius = (float)(box.CornerRadius); 
			canvas.DrawRoundRect(new RectF(rect), radius, radius, paint);
		}
	}
