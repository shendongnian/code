        public class MyTable
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public MyTable(int Id, string Name, string Surname)
            {
                this.Id = Id;
                this.Name = Name;
                this.Surname = Surname;
            }
        }
