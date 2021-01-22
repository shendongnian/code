    var members = typeof(TestMe).GetFields().Select(m => new 
                                             { 
                                                 Name = m.Name, 
                                                 MemType = m.MemberType, 
                                                 RtField = m.GetType(), 
                                                 Type = m.FieldType 
                                             });
    foreach (var item in members)
        Console.WriteLine("<{0}> <{1}> <{2}> <{3}> {3} {2}", item.MemType, item.RtField, item.Name, item.Type, item.Type, item.Name);
    public class TestMe
    {
        public string A;
        public int B;
        public byte C;
        public decimal D;
    }
