    // 2nd version
    public class ScreenDrawer
    {
        private Screen _screenNext;
        public ScreenDrawer(Screen screenNext, ...) : base (...)
        {
            _screenNext=screenNext;
        }
        public void Draw()
        {
            // draw himself
            if ( _screenNext!=null ) _screenNext.Draw();
        }
    }
    public class ScreenManager
    {
        public void Draw()
        {
            _screens[0].Draw();
        }
    }
    static void Main()
    {
        var screenOne = new ScreenDrawer(null, ...);
        var screenTwo = new ScreenDrawer(screenOne, ...);
        var screens = new []{screenOne, screenTwo};
        var screenManager = new ScreenManager(screens);
    }
