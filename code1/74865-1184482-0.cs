    [DataContract]
    public class PollParameters {
        [DataMember(Required = true)]
        public int Id;
    }
    
    [OperationContract]
    public StudentInfo Poll(PollParameters parameters);
