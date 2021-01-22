    public class ZeroGrid
        : Grid
    {
        protected override Size MeasureOverride(Size constraint)
        {
            base.MeasureOverride(constraint);
            return new Size();
        }
    }
