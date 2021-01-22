    // 1st version
    public class Screen(Screen screenSubSequent)
    {
        private Screen _screenNext;
        public Screen(Screen screenNext)
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
        var screenOne = new Screen(null, ...);
        var screenTwo = new Screen(screenOne, ...);
        var screens = new []{screenOne, screenTwo};
        var screenManager = new ScreenManager(screens);
    }
