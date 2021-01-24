     class SomeClass
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Age { get; set; }
                public DateTime Birthdate { get; set; }
    
                public override string ToString()
                {
                    return $"{Id}{Name}{Age}{Birthdate.ToString("MMM-dd-yyyy")}";
                }
    
                public List<SomeClass> SearchForText(string textToSearch,List<SomeClass> collection)
                {
                    return collection.Where(x => x.ToString().Contains(textToSearch)).ToList();
                }
            }
