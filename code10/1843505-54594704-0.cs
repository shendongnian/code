    public class YourRepository
    {
        public Table2 Table2WithUniqueColumn456(Table1 table1)
        {
            using var context = new Table1Context();
            return context.Entry(table1)
                          .Collection(t1 => t1.Table2Objects)
                          .Query()
                          .FirstOrDefault(t2 => t2.UniqueColumnAtTable2ForGivenTable1Id == 456);
        }
    }
