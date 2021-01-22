    public abstract class BaseClass {
        protected int _bar;
        public int Bar { get { return _bar; } }
        protected void DoBaseStuff()
        {
            SetBar();
            //Do something with _bar;
        }
        protected abstract void SetBar();
    }
    public class ConcreteClass : BaseClass {
        protected override void SetBar() { _bar = 5; }
    }
