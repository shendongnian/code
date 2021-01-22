    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Threading;
    
    namespace wpf_appbar
    {
        public enum ABEdge : int
        {
            Left,
            Top,
            Right,
            Bottom,
            None
        }
    
        internal static class AppBarFunctions
        {
            [StructLayout(LayoutKind.Sequential)]
            private struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
                public RECT(Rect r)
                {
                    Left = (int)r.Left;
                    Right = (int)r.Right;
                    Top = (int)r.Top;
                    Bottom = (int)r.Bottom;
                }
                public static bool operator ==(RECT r1, RECT r2)
                {
                    return r1.Bottom == r2.Bottom && r1.Left == r2.Left && r1.Right == r2.Right && r1.Top == r2.Top;
                }
                public static bool operator !=(RECT r1, RECT r2)
                {
                    return !(r1 == r2);
                }
                public override bool Equals(object obj)
                {
                    return base.Equals(obj);
                }
                public override int GetHashCode()
                {
                    return base.GetHashCode();
                }
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct APPBARDATA
            {
                public int cbSize;
                public IntPtr hWnd;
                public int uCallbackMessage;
                public int uEdge;
                public RECT rc;
                public IntPtr lParam;
            }
    
            private enum ABMsg : int
            {
                ABM_NEW = 0,
                ABM_REMOVE,
                ABM_QUERYPOS,
                ABM_SETPOS,
                ABM_GETSTATE,
                ABM_GETTASKBARPOS,
                ABM_ACTIVATE,
                ABM_GETAUTOHIDEBAR,
                ABM_SETAUTOHIDEBAR,
                ABM_WINDOWPOSCHANGED,
                ABM_SETSTATE
            }
            private enum ABNotify : int
            {
                ABN_STATECHANGE = 0,
                ABN_POSCHANGED,
                ABN_FULLSCREENAPP,
                ABN_WINDOWARRANGE
            }
    
            private enum TaskBarPosition : int
            {
                Left,
                Top,
                Right,
                Bottom
            }
    
            [StructLayout(LayoutKind.Sequential)]
            class TaskBar
            {
                public TaskBarPosition Position;
                public TaskBarPosition PreviousPosition;
                public RECT Rectangle;
                public RECT PreviousRectangle;
                public int Width;
                public int PreviousWidth;
                public int Height;
                public int PreviousHeight;
                public TaskBar()
                {
                    Refresh();
                }
                public void Refresh()
                {
                    APPBARDATA msgData = new APPBARDATA();
                    msgData.cbSize = Marshal.SizeOf(msgData);
                    SHAppBarMessage((int)ABMsg.ABM_GETTASKBARPOS, ref msgData);
                    PreviousPosition = Position;
                    PreviousRectangle = Rectangle;
                    PreviousHeight = Height;
                    PreviousWidth = Width;
                    Rectangle = msgData.rc;
                    Width = Rectangle.Right - Rectangle.Left;
                    Height = Rectangle.Bottom - Rectangle.Top;
                    int h = (int)SystemParameters.PrimaryScreenHeight;
                    int w = (int)SystemParameters.PrimaryScreenWidth;
                    if (Rectangle.Bottom == h && Rectangle.Top != 0) Position = TaskBarPosition.Bottom;
                    else if (Rectangle.Top == 0 && Rectangle.Bottom != h) Position = TaskBarPosition.Top;
                    else if (Rectangle.Right == w && Rectangle.Left != 0) Position = TaskBarPosition.Right;
                    else if (Rectangle.Left == 0 && Rectangle.Right != w) Position = TaskBarPosition.Left;
                }
            }
    
            [DllImport("SHELL32", CallingConvention = CallingConvention.StdCall)]
            private static extern uint SHAppBarMessage(int dwMessage, ref APPBARDATA pData);
    
            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            private static extern int RegisterWindowMessage(string msg);
    
            private class RegisterInfo
            {
                public int CallbackId { get; set; }
                public bool IsRegistered { get; set; }
                public Window Window { get; set; }
                public ABEdge Edge { get; set; }
                public ABEdge PreviousEdge { get; set; }
                public WindowStyle OriginalStyle { get; set; }
                public Point OriginalPosition { get; set; }
                public Size OriginalSize { get; set; }
                public ResizeMode OriginalResizeMode { get; set; }
    
    
                public IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam,
                                        IntPtr lParam, ref bool handled)
                {
                    if (msg == CallbackId)
                    {
                        if (wParam.ToInt32() == (int)ABNotify.ABN_POSCHANGED)
                        {
                            PreviousEdge = Edge;
                            ABSetPos(Edge, PreviousEdge, Window);
                            handled = true;
                        }
                    }
                    return IntPtr.Zero;
                }
    
            }
            private static Dictionary<Window, RegisterInfo> s_RegisteredWindowInfo
                = new Dictionary<Window, RegisterInfo>();
            private static RegisterInfo GetRegisterInfo(Window appbarWindow)
            {
                RegisterInfo reg;
                if (s_RegisteredWindowInfo.ContainsKey(appbarWindow))
                {
                    reg = s_RegisteredWindowInfo[appbarWindow];
                }
                else
                {
                    reg = new RegisterInfo()
                    {
                        CallbackId = 0,
                        Window = appbarWindow,
                        IsRegistered = false,
                        Edge = ABEdge.None,
                        PreviousEdge = ABEdge.None,
                        OriginalStyle = appbarWindow.WindowStyle,
                        OriginalPosition = new Point(appbarWindow.Left, appbarWindow.Top),
                        OriginalSize =
                            new Size(appbarWindow.ActualWidth, appbarWindow.ActualHeight),
                        OriginalResizeMode = appbarWindow.ResizeMode,
                    };
                    s_RegisteredWindowInfo.Add(appbarWindow, reg);
                }
                return reg;
            }
    
            private static void RestoreWindow(Window appbarWindow)
            {
                RegisterInfo info = GetRegisterInfo(appbarWindow);
    
                appbarWindow.WindowStyle = info.OriginalStyle;
                appbarWindow.ResizeMode = info.OriginalResizeMode;
                appbarWindow.Topmost = false;
    
                Rect rect = new Rect(info.OriginalPosition.X, info.OriginalPosition.Y,
                    info.OriginalSize.Width, info.OriginalSize.Height);
                appbarWindow.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle,
                        new ResizeDelegate(DoResize), appbarWindow, rect);
    
            }
    
            
            public static void SetAppBar(Window appbarWindow, ABEdge edge)
            {
                RegisterInfo info = GetRegisterInfo(appbarWindow);
                info.Edge = edge;
    
                APPBARDATA abd = new APPBARDATA();
                abd.cbSize = Marshal.SizeOf(abd);
                abd.hWnd = new WindowInteropHelper(appbarWindow).Handle;
    
                if (edge == ABEdge.None)
                {
                    if (info.IsRegistered)
                    {
                        SHAppBarMessage((int)ABMsg.ABM_REMOVE, ref abd);
                        info.IsRegistered = false;
                    }
                    RestoreWindow(appbarWindow);
                    info.PreviousEdge = info.Edge;
                    return;
                }
    
                if (!info.IsRegistered)
                {
                    info.IsRegistered = true;
                    info.CallbackId = RegisterWindowMessage("AppBarMessage");
                    abd.uCallbackMessage = info.CallbackId;
    
                    uint ret = SHAppBarMessage((int)ABMsg.ABM_NEW, ref abd);
    
                    HwndSource source = HwndSource.FromHwnd(abd.hWnd);
                    source.AddHook(new HwndSourceHook(info.WndProc));
                }
    
                appbarWindow.WindowStyle = WindowStyle.None;
                appbarWindow.ResizeMode = ResizeMode.NoResize;
                appbarWindow.Topmost = true;
    
                ABSetPos(info.Edge, info.PreviousEdge, appbarWindow);
            }
    
            private delegate void ResizeDelegate(Window appbarWindow, Rect rect);
            private static void DoResize(Window appbarWindow, Rect rect)
            {
                appbarWindow.Width = rect.Width;
                appbarWindow.Height = rect.Height;
                appbarWindow.Top = rect.Top;
                appbarWindow.Left = rect.Left;
            }
    
            static TaskBar tb = new TaskBar();
    
            private static void ABSetPos(ABEdge edge, ABEdge prevEdge, Window appbarWindow)
            {
                APPBARDATA barData = new APPBARDATA();
                barData.cbSize = Marshal.SizeOf(barData);
                barData.hWnd = new WindowInteropHelper(appbarWindow).Handle;
                barData.uEdge = (int)edge;
                RECT wa = new RECT(SystemParameters.WorkArea);
                tb.Refresh();
                switch (edge)
                {
                    case ABEdge.Top:
                        barData.rc.Left = wa.Left - (prevEdge == ABEdge.Left ? (int)Math.Round(appbarWindow.ActualWidth) : 0);
                        barData.rc.Right = wa.Right + (prevEdge == ABEdge.Right ? (int)Math.Round(appbarWindow.ActualWidth) : 0);
                        barData.rc.Top = wa.Top - (prevEdge == ABEdge.Top ? (int)Math.Round(appbarWindow.ActualHeight) : 0) - ((tb.Position != TaskBarPosition.Top && tb.PreviousPosition == TaskBarPosition.Top) ? tb.Height : 0) + ((tb.Position == TaskBarPosition.Top && tb.PreviousPosition != TaskBarPosition.Top) ? tb.Height : 0);
                        barData.rc.Bottom = barData.rc.Top + (int)Math.Round(appbarWindow.ActualHeight);
                        break;
                    case ABEdge.Bottom:
                        barData.rc.Left = wa.Left - (prevEdge == ABEdge.Left ? (int)Math.Round(appbarWindow.ActualWidth) : 0);
                        barData.rc.Right = wa.Right + (prevEdge == ABEdge.Right ? (int)Math.Round(appbarWindow.ActualWidth) : 0);
                        barData.rc.Bottom = wa.Bottom + (prevEdge == ABEdge.Bottom ? (int)Math.Round(appbarWindow.ActualHeight) : 0) - 1 + ((tb.Position != TaskBarPosition.Bottom && tb.PreviousPosition == TaskBarPosition.Bottom) ? tb.Height : 0) - ((tb.Position == TaskBarPosition.Bottom && tb.PreviousPosition != TaskBarPosition.Bottom) ? tb.Height : 0);
                        barData.rc.Top = barData.rc.Bottom - (int)Math.Round(appbarWindow.ActualHeight);
                        break;
                }
    
                SHAppBarMessage((int)ABMsg.ABM_QUERYPOS, ref barData);
                switch (barData.uEdge)
                {
                    case (int)ABEdge.Bottom:
                        if (tb.Position == TaskBarPosition.Bottom && tb.PreviousPosition == tb.Position)
                        {
                            barData.rc.Top += (tb.PreviousHeight - tb.Height);
                            barData.rc.Bottom = barData.rc.Top + (int)appbarWindow.ActualHeight;
                        }
                        break;
                    case (int)ABEdge.Top:
                        if (tb.Position == TaskBarPosition.Top && tb.PreviousPosition == tb.Position)
                        {
                            if (tb.PreviousHeight - tb.Height > 0) barData.rc.Top -= (tb.PreviousHeight - tb.Height);
                            barData.rc.Bottom = barData.rc.Top + (int)appbarWindow.ActualHeight;
                        }
                        break;
                }
                SHAppBarMessage((int)ABMsg.ABM_SETPOS, ref barData);
    
                Rect rect = new Rect((double)barData.rc.Left, (double)barData.rc.Top, (double)(barData.rc.Right - barData.rc.Left), (double)(barData.rc.Bottom - barData.rc.Top));
                appbarWindow.Dispatcher.BeginInvoke(new ResizeDelegate(DoResize), DispatcherPriority.ApplicationIdle, appbarWindow, rect);
            }
        }
    }
