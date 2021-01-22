    public class VesselSequence : IVesselSequence
    {
        public int AllocationId { get; set; }
        public string ScenarioName { get; set; }
    }
    
    [DataContract(Namespace = ...........)]
    interface IVesselSequence
    {
        [DataMember]
        int AllocationId { get; set; }
        [DataMember]
        string ScenarioName { get; set; }
    }
