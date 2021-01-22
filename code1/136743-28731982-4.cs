    class Program
    {
        static void Main(string[] args)
        {
            var writer = new CsvWriter<Person>("Persons.csv");
    
            writer.AddFormatter<DateTime>(d => d.ToString("MM/dd/yyyy"));
    
            writer.WriteHeaders();
            writer.WriteRows(GetPersons());
    		
    		writer.Flush();
    		writer.Close();
        }
    
        private static IEnumerable<Person> GetPersons()
    	{
    		yield return new Person
    			{
                    FirstName = "Jhon", 
                    LastName = "Doe", 
                    Sex = 'M'
                };
    			
            yield return new Person
                {
                    FirstName = "Jhane", 
                    LastName = "Doe",
                    Sex = 'F',
                    BirthDate = DateTime.Now
                };
            }
        }
    
    
        class Person
        {
            public string FirstName { get; set; }
    
            public string LastName { get; set; }
    
            public char Sex  { get; set; }
    
            public DateTime BirthDate { get; set; }
        }
