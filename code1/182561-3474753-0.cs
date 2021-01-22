    public class MyTest
    {
        System.Threading.Timer _timer;
        public MyTest()
        {
           _timer = new Timer(WorkMethod, 15000, 15000);
        }
        public void WorkMethod()
        {
           _timer.Change(Timeout.Infinite, Timeout.Infinite); // suspend timer
           // do work
           _timer.Change(15000, 15000); //resume
        }
    }
