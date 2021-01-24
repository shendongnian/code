    public class Foo
    {
        public int FooId { get; set; }
        public List<Bar> Bars { get; set; }
        [NotMapped]
        public List<Bar> BarWithTypeA { get => Bars.Where(x => x.BarType == 1).ToList() }
        [NotMapped]
        public List<Bar> BarWithTypeB { get => Bars.Where(x => x.BarType == 2).ToList() }
    }
