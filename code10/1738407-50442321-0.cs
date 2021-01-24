       public class ColMap : CsvClassMap<Column>
       {
           public ColMap()
           {
               Map(m=>m.ID).Name("ID").Index(0);
               .
               .
               .
           }
        }
