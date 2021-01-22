        public class Test
        {
            public string Name { get; set; } public int age { get; set; }
        }
        public class Employee
        {
            public Test[] test { get; set; }
            public Employee()
            {
                test = new Test[1];
                this.test[0] = new Test();
                this.test[0].Name = "Tom";
                this.test[0].age = 13;
            }
        }
