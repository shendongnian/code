    public ObservableCollection<ContractorAddValue> GetContractorsOrderByCity()
                {
                    var allContractors = (from c in db.Member where c.IsContrator == true select c).ToList();
                    //var allContractors2 = db.Member .Include(c => c.MemberAddress).SelectMany(c => c.MemberAddress).OrderBy(c => c.City).Select(c => c.Member ).ToList(); 
                    //var allContractors = (from c in db.Member  where c.IsContrator == true select c).OrderBy(c => c.MemberAddress.OrderBy(x => x.City)).ToList(); <= dosent work
        
                    var listContractorAddValue = new ObservableCollection<ContractorAddValue>();
        
                    foreach (var i in allContractors)
                    {
                        var adressList = db.MemberAddress.Where(x => x.MemberId == i.MemberId).OrderBy(x => x.City).ToList();
        
                        ContractorAddValue contractorAddValue = new ContractorAddValue();
                        contractorAddValue.Member = i;
                        contractorAddValue.AddAddress = new BaseCommand(() => ContractorsViewModel.SendAddress(i.MemberId ));
                        contractorAddValue.Addresses = new List<Addresses>();
        
                        foreach (var a in adressList)
                        {
                            Addresses memberAdress = new Addresses();
                            memberAdress.MemberAddress = a;
                            memberAdress.EditAddress = new BaseCommand(() => ContractorsViewModel.SendEditAddress(a.MemberAddressId , i.MemberId ));
                            contractorAddValue.Addresses.Add(memberAdress);
                        }
                        if(!listContractorAddValue.Contains(contractorAddValue)){
                            listContractorAddValue.Add(contractorAddValue);
                        } else {
                           var contAddValue = listContractorAddValue.First(l => l.Equals( contractorAddValue));
                          contAddValue.Addresses.AddRange(contractorAddValue.Addresses);           
                        }
                    }
                    return listContractorAddValue;
                }
