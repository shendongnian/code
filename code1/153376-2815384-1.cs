    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("B4CAC74B-ADE0-4ac7-AD0E-26E6439F9CF7")]
    public interface _IPerson
    {
        string FirstName { get; set; }     
        string LastName { get; set; }     
    }
    
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("A3C553DC-A348-43e4-957A-F94D23E3300E")]
    public class Person :  _IPerson      
    {      
        public string FirstName { get; set; }      
        public string LastName { get; set; }      
    }
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("4B527235-6738-4853-BEA0-FB3087C89291")]
    public interface _ComTester
    {
         string EchoPerson(Person person);
    }
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("C753D72B-C802-44ae-946A-E3F6D7C5D14B")]
    public class ComTester : _ComTester
    {
        public string EchoPerson(Person person)
        {
            return person.FirstName + " " + person.LastName;
        }
    }
