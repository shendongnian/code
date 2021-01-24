     public class MainTable
        {
            public int MainTableID;
            public int TableChildOneID;
            public int TableChildTwoID;
            //... many properties
        }
    
        public class TableChildOne
        {
            public int TableChildOneID;
            //... many properties
        }
    
        public class TableChildTwo
        {
            public int TableChildTwoID;
            //... many properties
        }
    
        public class MainTable_Extended
        {
            public TableChildOne ChildOne { get; set; }
            public TableChildTwo ChildTwo { get; set; }
            public MainTable Main { get; set; }
        }
    
        public class DB : DbContext
        {
            public DB()
                : base("name=YourName")
            {
            }
    
            public virtual DbSet<MainTable> MainTables { get; set; }
            public virtual DbSet<TableChildOne> TableChildOnes { get; set; }
            public virtual DbSet<TableChildTwo> TableChildTwos { get; set; }
        }
    
        public class Test
        {
            public void TestTest()
            {
                var db = new DB();
    
                IQueryable<MainTable_Extended> listMainTable =
                from main in db.MainTables
                from childone in db.TableChildOnes.Where(childone => childone.TableChildOneID == main.TableChildOneID).DefaultIfEmpty()
                from childtwo in db.TableChildTwos.Where(childtwo => childtwo.TableChildTwoID == main.TableChildTwoID).DefaultIfEmpty()
                select new MainTable_Extended
                {
                    ChildOne = childone,
                    ChildTwo = childtwo,
                    Main = main
                };
            }
        }
 
