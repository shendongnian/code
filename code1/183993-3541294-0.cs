    public class MyTrackBar : TrackBar
    {
        public bool SuspendChangedEvent
        { get; set; }
        protected override void OnValueChanged(EventArgs e)
        {
            if (!SuspendChangedEvent) base.OnValueChanged(e);
        }
    }
