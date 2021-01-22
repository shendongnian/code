    [Class(Table = "SpecificitySets", Name = "ZslSpecificityTable")]
    public class SpecificityTable
    {
        [Id(0, TypeType = typeof(ulong), Name = "Id")]
        [Generator(1, Class = "native")]
        public uint Id 
    
        [Map(1, Name = "Table", Table = "SpecificityMapping")]
        [Key(1, Column = "SpecTableId")]
        [Index(3, Column = "Term", Type="string")]
        [Element(4, Column = "Value", Type="double")]
        public virtual IDictionary<string, double> Table { get; private set; }
    
        // ...
    }
