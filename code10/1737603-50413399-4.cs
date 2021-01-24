    public abstract class InputBase
    {
        public virtual bool Option1 { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual DateTime DateCreated { get; set; }
    }
    public class C : InputBase
    {
        private bool _option1;
        public override bool Option1
        {
            get => _option1;
            set
            {
                _option1 = value;
                A.Option1 = value;
                B.Option1 = value;
            }
        }
        private decimal _rate;
        public override decimal Rate
        {
            get => _rate;
            set
            {
                _rate = value;
                A.Rate = value;
                B.Rate = value;
            }
        }
        private DateTime _dateCreated;
        public override DateTime DateCreated
        {
            get => _dateCreated;
            set
            {
                _dateCreated = value;
                A.DateCreated = value;
                B.DateCreated = value;
            }
        }
        public A A { get; }
        public B B { get; }
    }
