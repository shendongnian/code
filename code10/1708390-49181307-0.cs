    public class TestClass
    {
        public RecordStatus RecordStatus { get; set; } = RecordStatus.Active;
    
        [System.ComponentModel.Browsable(false)]
        public DateTime CreatedOn { get; set; }
    }
