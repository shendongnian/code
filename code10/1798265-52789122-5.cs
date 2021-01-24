        static void Report(List<Family> Families, List<Person> children)
        {
            foreach (var family in Families)
            {
                Console.WriteLine($"{family.Nickname} ({family.FamilyId})");
                Console.WriteLine("Prents : ");
                Console.WriteLine($"{family.father.name} - {family.father.job} - { family.father.licNumber}");
                Console.WriteLine($"{family.mother.name} - {family.mother.job} - {family.mother.licNumber}");
                Console.WriteLine("Kids");
                foreach (Person child in children)
                  if (child.FamilyId == family.FamilyId)
                     Console.WriteLine("Child: " + child.name);
             }
        }
