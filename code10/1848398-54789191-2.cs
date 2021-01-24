    public class C
    {
        public C(B b)
        {
            b.RaisePropertyChanged(nameof(b.SomeProperty));
        }
    }
