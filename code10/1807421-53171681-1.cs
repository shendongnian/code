    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace WindowsFormsApp11
    {
        public class WinFormMonitor : IDisposable
        {
            private readonly IntPtr _eventHook;
            private readonly IList<Form> _detectedForms = new List<Form>();
            public event EventHandler<Form> NewFormCreated = (sender, form) => { };
            public WinFormMonitor()
            {
                _eventHook = SetWinEventHook(
                    EVENT_OBJECT_CREATE,
                    EVENT_OBJECT_CREATE,
                    IntPtr.Zero,
                    WinEventProc,
                    0,
                    0,
                    WINEVENT_OUTOFCONTEXT);
            }
            public void Dispose()
            {
                _detectedForms.Clear();
                UnhookWinEvent(_eventHook);
            }
            private void WinEventProc(IntPtr hWinEventHook, uint eventType,
                IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
            {
                if (idObject != 0 || idChild != 0) return;
                if (!TryFindForm(hwnd, out var foundForm)) return;
                if (_detectedForms.Contains(foundForm)) return;
                NewFormCreated(this, foundForm);
                _detectedForms.Add(foundForm);
            }
            private static bool TryFindForm(IntPtr handle, out Form foundForm)
            {
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm.Handle != handle) continue;
                    foundForm = openForm;
                    return true;
                }
                
                foundForm = null;
                return false;
            }
            private const uint EVENT_OBJECT_CREATE = 0x8000;
            private const uint WINEVENT_OUTOFCONTEXT = 0;
            private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType,
                IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
            [DllImport("user32.dll")]
            private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
                    hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
                uint idThread, uint dwFlags);
            [DllImport("user32.dll")]
            private static extern bool UnhookWinEvent(IntPtr hWinEventHook);
        }
    }
