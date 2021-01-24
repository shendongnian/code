    Public class FamilyMember 
    {
        public string Name {private set; get;}
        public int Age { private set; get; }
        
        public FamilyMember(string name, int age)
            {
                Name = name;
                Age = age;
            }
        public void IncrementAge()
        {
            Age++;
        }
    }
    
    Public void IncrementAgeOfFamilyMembers(List<FamilyMember> FamilyMembers)
    {
         foreach (var fmember in FamilyMembers)
             fmember.IncrementAge();
    }
