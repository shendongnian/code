    [DataContract]
    [KnownType(typeof(Bla1))]
    public class Bla
    {
        [DataMember] public int id;
        public Bla(int id)
        {
            this.id = id;
        }
    }
