    class Thing {
        public int ThingId { get; set; }
        public string ThingName { get; set; }
        public string UnnecessaryProp {get;set;}
    }
    class ThingViewModel {
        public int ThingId { get; set; }
        public string ThingName { get; set; }
    }
    class MyView {
        public IEnumerable<ThingViewModel> Things {get;set;}
    }
