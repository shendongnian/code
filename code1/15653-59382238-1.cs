    using System;
    using System.ComponentModel;
    public class DisposableWrapperComponent : Component
    {
        private bool disposed;
        public IDisposable Disposable { get; }
        public DisposableWrapperComponent(IDisposable disposable)
        {
            Disposable = disposable ?? throw new ArgumentNullException(nameof(disposable));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                Disposable.Dispose();
            }
            base.Dispose(disposing);
            disposed = true;
        }
    }
