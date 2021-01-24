    private static void PrintFamily(Family family)
    {
         Console.WriteLine($"{family.Nickname} ({family.FamilyId})");
         Console.WriteLine("Prents : ");
         Console.WriteLine($"{family.father.name} - {family.father.job} - { fam1.father.licNumber}");
         Console.WriteLine($"{family.mother.name} - {family.mother.job} - {family.mother.licNumber}");
        if(familiy.Children!=null && familiy.Children.Any()
        {
         Console.WriteLine("Kids");
            foreach{var child in family.Children}
            {
                 Console.WriteLine($"{child .name} - {child .age}");
            }
        }
    }
