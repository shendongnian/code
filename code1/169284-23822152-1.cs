    [ProtoContract]
    public class MyOption
    {
        [ProtoMember(2), DefaultValue(View.Details)]
        public View m_printListView = View.Details;   (A)
        [ProtoMember(5), DefaultValue(true) ]
        public bool m_bool = true ;                   (B)
    }
