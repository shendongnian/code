    [Guid("BE5E0B60-F855-478E-9BE2-AA9FD945F177")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ICriteria
    {
        [DispId(1)]
        int ID { get; set; }
        [DispId(2)]
        string RateCardName { get; set; }
        [DispId(3)]
        string ElectionType { get; set; }
    }
    [Guid("3023F3F0-204C-411F-86CB-E6730B5F186B")]    
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("MyNameSpace.Criteria")]
    public class Criteria : ICriteria
    {
        public int ID { get; set; }
        public string RateCardName { get; set; }
        public string ElectionType { get; set; }
    }
