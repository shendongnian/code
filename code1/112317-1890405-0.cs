    class CustomFS : FS
    {
        protected override int GetStuff(int x)
        {
            return CustomHelper.GetStuff(base.GetStuff(x));
        }
    }
    
    class CustomFS2 : FS2
    {
        protected override int GetStuff(int x)
        {
            return CustomHelper.GetStuff(base.GetStuff(x));
        }
    }
    
    static class CustomHelper
    {
        static int GetStuff(int x)
        {
            return x + 1;
        }
    }
