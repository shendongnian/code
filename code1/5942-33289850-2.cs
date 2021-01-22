    public abstract class BaseClass
    {
        private int _foo;
        private int _bar;
        private int _baz;
        private int _wtf;
        private int _kthx;
        private int _lawl;
        public int Bar
        {
            get { return _foo * _baz + _kthx; }
        }
        public bool TryDoSomethingBaz(MyEnum whatever, int input)
        {
            switch (whatever)
            {
                case MyEnum.lol:
                    _baz = _lawl + input;
                    return true;
                case MyEnum.wtf:
                    _baz = _wtf * input;
                    return false;
            }
        }
        public void TryBlowThingsUp(DateTime when)
        {
            //Some Crazy Madeup Code
            _kthx = DaysSinceEaster(when);
        }
        public int DaysSinceEaster(DateTime when)
        {
            return 2; //<-- calculations
        }
    }
    public enum MyEnum
    {
        lol,
        wtf,
    }
