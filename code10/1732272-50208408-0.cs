       public List<AgeVM> getuserAge()
            {
                List<AgeVM> listAgeVM = new List<AgeVM>();
                Dictionary<string, int> temp = new Dictionary<string, int>();
                temp.Add("teen", 0);
                temp.Add("Young", 0);
                temp.Add("Medioker", 0);
                temp.Add("Senior Citizen", 0);
                var res = from a in _Registrationrepository.GetAll()
                          select new
                          {
                              age = a.DOB,
                              name = a.FirstName,
    
                          };
                foreach (var item in res)
                {
    
                    AgeVM ageVM = new AgeVM();
                   //Write separate function to calculate age.                
                    string agegrp;
                    var realAge = currentYear - year;
                    if (realAge < 18 && realAge > 13)
                    {
                        agegrp = "teen";
                        temp[agegrp]++;
                    }
                    if (realAge < 26 && realAge > 18)
                    {
                        agegrp = "Young";
                        temp[agegrp]++;
                    }
                    if (realAge < 45 && realAge > 26)
                    {
                        agegrp = "Medioker";
                        temp[agegrp]++;
                    }
                    else
                    {
                        agegrp = "Senior Citizen";
                        temp[agegrp]++;
                    }
    
                    ageVM.AgeGroupName = agegrp;
                   //This is what you are missing.
                   ageVM.NoofUsers = temp[agegrp];
    
    
                    listAgeVM.Add(ageVM);
                }
    
                return listAgeVM;
    
            }
