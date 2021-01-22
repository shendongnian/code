    #region
    using System;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Interop;
    #endregion
    namespace System.Windows.Interop
    {
        /// <summary>
        ///   Provides NetFX 4.0 EnsureHandle method for
        ///   NetFX 3.5 WindowInteropHelper class.
        /// </summary>
        public static class WindowInteropHelperExtension
        {
            /// <summary>
            ///   Creates the HWND of the window if the HWND has not been created yet.
            /// </summary>
            /// <param name = "helper">An instance of WindowInteropHelper class.</param>
            /// <returns>An IntPtr that represents the HWND.</returns>
            /// <remarks>
            ///   Use the EnsureHandle method when you want to separate
            ///   window handle (HWND) creation from the
            ///   actual showing of the managed Window.
            /// </remarks>
            public static IntPtr EnsureHandle(this WindowInteropHelper helper)
            {
                if (helper == null)
                    throw new ArgumentNullException("helper");
                if (helper.Handle == IntPtr.Zero)
                {
                    var window = (Window) typeof (WindowInteropHelper).InvokeMember(
                        "_window",
                        BindingFlags.GetField |
                        BindingFlags.Instance |
                        BindingFlags.NonPublic,
                        null, helper, null);
                    typeof (Window).InvokeMember(
                        "SafeCreateWindow",
                        BindingFlags.InvokeMethod |
                        BindingFlags.Instance |
                        BindingFlags.NonPublic,
                        null, window, null);
                }
                return helper.Handle;
            }
        }
    }
