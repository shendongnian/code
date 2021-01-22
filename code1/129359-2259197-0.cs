    public class Core
    {
         internal static MyWindowClass m_Wnd = null;
         // call this when your non-static form is created
         //
         public static void SetWnd(MyWindowClass wnd)
         {
             m_Wnd = wnd;
         }
         public static MyWindow { get { return m_Wnd; } }
    }
