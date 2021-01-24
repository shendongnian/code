    public class CsvItem_WithARealName
    {
        public int data1;
        public decimal data2;
        public int goodVariableNames;
    }
    public class CsvItemMapper : ClassMap<CsvItem_WithARealName>
    {
        public CsvItemMapper()
        {   //mapping based on index. cause file has no header.
            Map(m => m.data1).Index(0);
            Map(m => m.data2).Index(1);
            Map(m => m.goodVariableNames).Index(2);
        }
    }
