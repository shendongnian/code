    public class DerivedDisposable : BaseDisposable
    {
        public DerivedDisposable()
        {
            // acquire resources for DerivedDisposable
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // release DerivedDisposable's managed resources
            }
            // release DerivedDisposable's unmanaged resources
            // Let the base class do its thing
            base.Dispose(disposing);
        }
    }
