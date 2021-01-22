    public class CustomDoubleList : CustomList<double, List<double>> {
        public CustomDoubleList() : base(new List<double>()) {
            _list = new List<double>(); // crap!
        }
    }
