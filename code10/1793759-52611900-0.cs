    public interface IReloader
    {
        (Action Show, Action Hide) GetActions();
    }
    public abstract class Reloader : IReloader
    {
        public (Action Show, Action Hide) GetActions()
        {
            return (Show, Hide);
        }
        protected virtual void Show() { }
        protected virtual void Hide() { }
    }
    public class FastReloader : Reloader { }
    public class AView
    {
        public Action Show{ get; set; }
        public Action Hide{ get; set; }
        public void IwantTheNewActions()
        {
            var reloader = new FastReloader();
            var actions = reloader.GetActions();
            Show = actions.Show;
            Hide = actions.Hide;
        }
    }
