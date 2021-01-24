            class Option
            {
                public int Id { get; set; }
    
                public string Name { get; set; }
    
                public Priority Priority { get; set; }
            }
    
            enum Priority
            {
                Gold = 0,
                Silver,
                Bronze
            }
    
            static void Main(string[] args)
            {
                var list = new List<Option>()
                {
                    new Option { Id = 1, Name = "Bob", Priority = Priority.Gold },
                    new Option { Id = 2, Name = "Rob", Priority = Priority.Gold },
                    new Option { Id = 2, Name = "David", Priority = Priority.Bronze },
                    new Option { Id = 2, Name = "Adam", Priority = Priority.Bronze },
                    new Option { Id = 2, Name = "Jack", Priority = Priority.Silver },
                    new Option { Id = 2, Name = "Josh", Priority = Priority.Silver },
                    new Option { Id = 2, Name = "Peter", Priority = Priority.Silver },
                    new Option { Id = 2, Name = "Max", Priority = Priority.Silver },
                    new Option { Id = 2, Name = "Steve", Priority = Priority.Silver },
                };
    
                var newList = list.OrderBy(l => l.Priority).Take(5);
    }
