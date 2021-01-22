    class SomeClass {
        public string SomeProperty { get; set; }
    }
    MemberInfo member = GetMemberInfo((SomeClass s) => s.SomeProperty);
    Console.WriteLine(member.Name); // prints "SomeProperty" on the console
    
