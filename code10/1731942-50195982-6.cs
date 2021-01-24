    public enum Colour
    {
        Green,
        Red,
        Disable
    }
    public abstract class RailwayUser
    {
        private string className;
        public RailwayUser()
        {
            Type type = this.GetType();
            className = type.Name;
        }
        public void PrintClassName()
        {
            Console.WriteLine(className);
        }
        public abstract void Notice(Colour state);
    }
    public class Driver : RailwayUser
    {
        public override void Notice(Colour state)
        {
            Console.WriteLine("Driver see the "+ state.ToString());
        }
    }
    public class Controller : RailwayUser
    {
        public override void Notice(Colour state)
        {
            Console.WriteLine("Controller see the " + state.ToString());
        }
    }
    public class RailwaySignal
    {
        public delegate void NoticeEvent(Colour state);
        public event NoticeEvent Notifys;
        public Colour Stata { get; set; }
        public void Notify()
        {
            if (Notifys != null)
            {
                Notifys(Stata);
            }
        }
    }
