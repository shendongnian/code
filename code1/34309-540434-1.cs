    [DataContract]
    public class Wrapper {
        [DataMember(Order = 1)]
        public List<Foo> Foos {get {...}}
        [DataMember(Order = 2)]
        public List<Bar> Bars {get {...}}
        [DataMember(Order = 3)]
        public List<Blop> Blops {get {...}}
    }
