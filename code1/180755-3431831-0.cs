    public class SysState
    {
        public bool Process(Information info)
        {
            return ( info.Good );
        }
    }
    public class Normal
    {
        public bool Process(Information info)
        {
            return doStuff();
        }
    }
    public class Foobar
    {
        public bool Process(Information info)
        {
            return diePainfully();
        }
    }
