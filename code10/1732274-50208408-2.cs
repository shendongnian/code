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
                        temp["teen"]++;
                    }
                    if (realAge < 26 && realAge > 18)
                    {
                        temp["Young"]++;
                    }
                    if (realAge < 45 && realAge > 26)
                    {
                        temp["Medioker"]++;
                    }
                    else
                    {
                        temp["Senior Citizen"]++;
                    }
                }
      //Now outside foreach loop iterate through each key, value pair of dictionary and assing key to `AgeGroupName` and value to `NoofUsers` property
    foreach(KeyValuePair<string, int> item in temp)
    {
     
           ageVM.AgeGroupName = item.Key;
           ageVM.NoofUsers = item.Value;
    }
                return listAgeVM;
    
            }
