    public class Metronome
    {
        public event EventHandler Tick =+ (s,e) => {};
        protected virtual void OnTick(EventArgs e)
        {
            Tick(this, e);  // now it's safe to call without the null check.
        }
    }
