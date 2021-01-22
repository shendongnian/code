    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Input;
    public class WpfHourGlass : IDisposable
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct POINTAPI
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct MSG
        {
            public int hwnd;
            public int message;
            public int wParam;
            public int lParam;
            public int time;
            public POINTAPI pt;
        }
        private const short PM_REMOVE = 0x1;
        private const short WM_MOUSELAST = 0x209;
        private const short WM_MOUSEFIRST = 0x200;
        private const short WM_KEYFIRST = 0x100;
        private const short WM_KEYLAST = 0x108;
        [DllImport("user32", EntryPoint = "PeekMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int PeekMessage([MarshalAs(UnmanagedType.Struct)]
        ref MSG lpMsg, int hwnd, int wMsgFilterMin, int wMsgFilterMax, int wRemoveMsg);
        public WpfHourGlass()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            bActivated = true;
        }
        public void Show(bool Action = true)
        {
            if (Action)
            {
                Mouse.OverrideCursor = Cursors.Wait;
            }
            else
            {
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            bActivated = Action;
        }
        #region "IDisposable Support"
        // To detect redundant calls
        private bool disposedValue;
        private bool bActivated;
        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    //remove todas as mensagens de mouse
                    //e teclado que tenham sido produzidas
                    //durante o processamento e estejam
                    //enfileiradas
                    if (bActivated)
                    {
                        MSG pMSG = new MSG();
                        while (Convert.ToBoolean(PeekMessage(ref pMSG, 0, WM_KEYFIRST, WM_KEYLAST, PM_REMOVE)))
                        {
                        }
                        while (Convert.ToBoolean(PeekMessage(ref pMSG, 0, WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE)))
                        {
                        }
                        Mouse.OverrideCursor = Cursors.Arrow;
                    }
                }
                // TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                // TODO: set large fields to null.
            }
            this.disposedValue = true;
        }
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
