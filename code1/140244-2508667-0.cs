    [Class(Table = "SpecificitySets", Name = "ZslSpecificityTable")]
    public class SpecificityTable
    {
        [Id(0, TypeType = typeof(ulong), Name = "Id")]
        [Generator(1, Class = "native")]
        public uint Id 
    
        [Map(0, Name = "Table", Table = "SpecificityMapping")]
        [Key(1, Column = "SpecTableId")]
        [Index(2, Column = "Term", Type="System.String")]
        [Element(3, Column = "Value", Type="System.Double")]
        public virtual IDictionary<string, double> Table { get; private set; }
    
        // ...
    }
