    [DataContract(Namespace = ...........)]
    public class VesselSequence : IVesselSequence
    {
        [DataMember]
        public int AllocationId { get; set; }
        [DataMember]
        public string ScenarioName { get; set; }
    }
    
    interface IVesselSequence
    {
        int AllocationId { get; set; }
        string ScenarioName { get; set; }
    }
