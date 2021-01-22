    public class Player : IDisposable
    {
        private IntPtr _thePlayer;
        public Player()
        {
            _thePlayer = CreatePlayer();
        }
        ~Player()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
        }
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
               // dispose of managed objects (ie, not native resources only)
            }
            if (_thePlayer != IntPtr.Empty)
            {
                DestroyPlayer(_thePlayer);
                _thePlayer = IntPtr.Empty;
            }
        }
        [DllImport("gameengine.dll")]
        private static extern IntPtr CreatePlayer();
        [DllImport("gameengine.dll")]
        private static extern void DestroyPlayer(IntPtr player);
    }
