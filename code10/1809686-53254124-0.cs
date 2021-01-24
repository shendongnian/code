    using ServerTest;
    using Terminal.Gui;
    
    namespace UI
    {
        public class UI
        {
            static Window win = null;
            public static void main()
            {
                win = new Window(new Rect(0, 0, Application.Top.Frame.Width, Application.Top.Frame.Height), "MyApp");
    
                Application.Init();
                win.Add(new Label(0, 0, "asd"));
    
                Application.Run(win);
            }
        }
    }
