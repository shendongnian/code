        static void Main(string[] args)
        {
            PersonalList personen = new PersonalList(); 
            personen.Listname = "Friends";
            // normal person
            Person normPerson = new Person();
            normPerson.ID = "0";
            normPerson.Name = "Max Man";
            normPerson.City = "Capitol City";
            normPerson.Age = 33;
            // special person
            SpecialPerson specPerson = new SpecialPerson();
            specPerson.ID = "1";
            specPerson.Name = "Albert Einstein";
            specPerson.City = "Ulm";
            specPerson.Age = 36;
            specPerson.Interests = "Physics";
            // super person
            SuperPerson supPerson = new SuperPerson();
            supPerson.ID = "2";
            supPerson.Name = "Superman";
            supPerson.Alias = "Clark Kent";
            supPerson.City = "Metropolis";
            supPerson.Age = int.MaxValue;
            supPerson.Skills.Add("fly");
            supPerson.Skills.Add("strong");
            // Add Persons
            personen.AddPerson(normPerson);
            personen.AddPerson(specPerson);
            personen.AddPerson(supPerson);
            // Serialize 
            Type[] personTypes = { typeof(Person), typeof(SpecialPerson), typeof(SuperPerson) };
            XmlSerializer serializer = new XmlSerializer(typeof(PersonalList), personTypes); 
            FileStream fs = new FileStream("Personenliste.xml", FileMode.Create); 
            serializer.Serialize(fs, personen); 
            fs.Close(); 
            personen = null;
            // Deserialize 
            fs = new FileStream("Personenliste.xml", FileMode.Open); 
            personen = (PersonalList)serializer.Deserialize(fs); 
            serializer.Serialize(Console.Out, personen);
            Console.ReadLine();
        }
