    class Program
    {
        static void Main(string[] args)
        {
            var foo = new List<Category>();
            // Example structure from Question
            var fail1 = new Category() { Name = "test1" };
            var fail2 = new Category() { Name = "test2", ParentCategory = fail1 };
            var fail3 = new Category() { Name = "test3", ParentCategory = fail1 };
            var fail4 = new Category() { Name = "test4"};
            var fail5 = new Category() { Name = "test5", ParentCategory = fail4 };
            var fail6 = new Category() { Name = "test6", ParentCategory = fail4 };
            var fail7 = new Category() { Name = "test7", ParentCategory = fail4 };
            foo.Add(fail1);
            foo.Add(fail4);
            recurseCategories(ref foo, null, 0);
        }
        
        static void recurseCategories(ref List<Category> cl, Category start, int level)
        {
            foreach (Category child in cl)
            {
                if (child.ParentCategory == start)
                {
                    Console.WriteLine(new String(' ', level) + child.Name);
                    recurseCategories(ref cl, child, level + 1);
                }
            }
        }
        public class Category
        {
            public string Name { get; set; }
            public Category ParentCategory { get; set; }
        }
    }
