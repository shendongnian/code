    [DataContract]
    public class MasterData
    {
        [DataMember]
        public IEnumerable<PROFILE> lstProfile { get; set; }
        [DataMember]
        public IEnumerable<COMPETENCE> lstCOMPETENCE { get; set; }
        [DataMember]
        public IEnumerable<TB> lstTB { get; set; }
        public MasterData() { }
    }
