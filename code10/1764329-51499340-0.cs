    //Models
    
    public class DropdownValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; } = new Property();
    }
    
    public class Property
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ValueTypes ValueType { get; set; } = new ValueTypes();
        public InputTypes InputType { get; set; } = new InputTypes();
        public List<DropdownValue> DropdownValues { get; set; } = new List<DropdownValue>();
    }
    //Dtos
    
    public class DropdownValueDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public PropertyDto Property { get; set; } = new PropertyDto();
    }
    
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public InputTypes InputType { get; set; } = new InputTypes();
        public ValueTypes ValueType { get; set; } = new ValueTypes();
    }
