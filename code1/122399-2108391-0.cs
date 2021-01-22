    public List<Pet> CreatePets(String PetData)
    {
         List<Pet> PetList = new List<Pet>();
         string[] PetArray = PetData.Split(new char[]{ '|' }, StringSplitOptions.None);
         for (int i = 0; i < PetArray.Count(); i += 2)
         {
               Pet NewPet= new Pet(Convert.ToInt32(PetArray[i]), PetArray[i+1]);
               PetList.Add(Field);
         }                
         return PetList;
    }
