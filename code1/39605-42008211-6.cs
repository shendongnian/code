    public abstract class WinApiServiceBase : IDisposable
    {
        /// <summary>
        /// Sponge window absorbs messages and lets other services use them
        /// </summary>
        private sealed class SpongeWindow : NativeWindow
        {
            public event EventHandler<Message> WndProced;
     
            public SpongeWindow()
            {
                CreateHandle(new CreateParams());
            }
     
            protected override void WndProc(ref Message m)
            {
                WndProced?.Invoke(this, m);
                base.WndProc(ref m);
            }
        }
     
        private static readonly SpongeWindow Sponge;
        protected static readonly IntPtr SpongeHandle;
     
        static WinApiServiceBase()
        {
            Sponge = new SpongeWindow();
            SpongeHandle = Sponge.Handle;
        }
     
        protected WinApiServiceBase()
        {
            Sponge.WndProced += LocalWndProced;
        }
     
        private void LocalWndProced(object sender, Message message)
        {
            WndProc(message);
        }
     
        /// <summary>
        /// Override to process windows messages
        /// </summary>
        protected virtual void WndProc(Message message)
        { }
     
        public virtual void Dispose()
        {
            Sponge.WndProced -= LocalWndProced;
        }
    }
