    public sealed class MyClassDTO
    {
        public string Name { get; set; }
        public static implicit operator MyClassDTO(MyClass obj) => obj == null ? null : new MyClassDTO { Name = obj.Name };
        public static implicit operator MyClass(MyClassDTO dto) => dto == null ? null : MyClass.Parse(dto.Name);
    }
