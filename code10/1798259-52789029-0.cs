            public static void Main(string[] args)
        {
            List<Family> Families = new List<Family>();
            Adults father = new Adults { Name = "Jim", Age = 34, Job = "Programmer", LicNumber = "2344454" };
            Adults father = new Adults { Name = "Amy", Age = 33, Job = "Nurse", LicNumber = "88888" };
            Family fam1 = new Family { Nickname = "Family One", FamilyId = 1, Father = father, Mother = mother };
        }
        private static void DisplayFamilyMemberInformation(Family familyMember)
        {
            Console.WriteLine($"{family.Nickname} ({family.FamilyId})");
            Console.WriteLine("Prents : ");
            Console.WriteLine($"{fam1.father.name} - {fam1.father.job} - { fam1.father.licNumber}");
            Console.WriteLine($"{fam1.mother.name} - {fam1.mother.job} - {fam1.mother.licNumber}");
        }
