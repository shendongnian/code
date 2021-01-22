    public class C : B
    {
        private IntPtr m_Handle;
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // get rid of managed resources
            }
            ReleaseHandle(m_Handle);
            base.Dispose(disposing);
        }
        ~C() {
            Dispose(false);
        }
    }
