    public class CustomRenderableSeriesViewModel : BaseRenderableSeriesViewModel
    {
        public override Type ViewType => typeof(CustomRenderableSeries);
        private bool _isSplineEnabled;
        public bool IsSplineEnabled
        {
            get { return _isSplineEnabled; }
            set { SetValue(ref _isSplineEnabled, value, "IsSplineEnabled"); }
        }
    }
