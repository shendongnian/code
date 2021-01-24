    //select provider types lookup, from there can map id with it text meaning, f.e.[{providerTypeId: 1, type: 'Value 1' },{providerTypeId: 2, type: 'Value 2' }]
    var providerTypes = exUrDataContext.vw_LookUpProviderType.ToList();
    //select physicianCois with unmodified providerTypeIds(f.e '1,2,')
    var physicianCois =
                    await (from providerCoi in dbContext.Provider_COI
                           where providerCoi.COIProviderId == message.PhysicianId
                           join providerDetail in exUrDataContext.vw_ProviderDetail
                           on providerCoi.ProviderId equals providerDetail.ProviderId
                           into providerDetails
                           from providerDetail in providerDetails.DefaultIfEmpty()
                           select new Result
                           {
                               PhysicianAdvisorId = providerCoi.ProviderId,
                               HasConflictOfInterest = providerCoi.COIFlag == true,
                               PhysicianAdvisorName = providerDetail.FirstName + " " + providerDetail.MiddleName + " " + providerDetail.LastName,
                               ProviderType = providerDetail.ProviderTypeIds
                           }).ToListAsync();
              
                //map string with ids to string from text values, f.e. '1,2' => 'Value 1, Value 2'
                foreach (var physicianCoi in physicianCois)
                {
                    string physicianProviderNames = "";
                    foreach (var providerKey in physicianCoi.ProviderType.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (!physicianProviderNames.Equals(""))
                        {
                            physicianProviderNames += ", ";
                        }
                        physicianProviderNames += providerTypes.Where(providerType => providerType.ProviderTypeId == int.Parse(providerKey)).FirstOrDefault().Type;
                    }
                    physicianCoi.ProviderType = physicianProviderNames;
                }
   
