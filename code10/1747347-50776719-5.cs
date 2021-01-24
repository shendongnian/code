	public class CustomTypefaceSpan : MetricAffectingSpan
	{
		readonly Typeface typeFace;
		public CustomTypefaceSpan(Typeface typeFace)
		{
			this.typeFace = typeFace;
		}
		public override void UpdateDrawState(TextPaint tp)
		{
			tp.SetTypeface(typeFace);
		}
		public override void UpdateMeasureState(TextPaint p)
		{
			p.SetTypeface(typeFace);
		}
	}
