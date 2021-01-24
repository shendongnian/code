    public class MotherTable
    {
        public int MotherId { get; set; }
        public int MainDiscriminator { get; set; }
        public string CommonAttribute1 { get; set; }
        public string CommonAttribute2 { get; set; }
    }
    public class ChildTable1 : MotherTable
    {
        public string AdditionalAttribute1 { get; set; }
    }
    public class ChildTable2 : MotherTable
    {
        public int SecondaryDiscriminator { get; set; }
        public string AdditionalAttribute2 { get; set; }
    }
    public class GrandChild1 : ChildTable2
    {
        public string AdditionalAttributes21 { get; set; }
    }
    public class GrandChild2 : ChildTable2
    {
        public string AdditionalAttributes22 { get; set; }
    }
