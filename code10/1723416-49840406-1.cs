                       var data = from lad in _db.Jobs
                                    join users in _db.Users on lad.Id equals users.Id into ul
                                    from users in ul.DefaultIfEmpty()
                                    join ladAddressLoading in _db.Addresses.Where(a => a.TAD_N_ID == 1) on lad.Id equals ladAddressLoading.Id
                                    join ladAddressDelivery in _db.Addresses.Where(a => a.TAD_N_ID == 2) on lad.Id equals ladAddressDelivery.Id
                                    join countryLoading in _db.Countries on ladAddressLoading.Id equals countryLoading.Id
                                    join countryDelivery in _db.Countries on ladAddressDelivery.Id equals countryDelivery.Id
                                    join volume in _db.Measurements on lad.Id equals volume.Id
                                    select new
                                    {
                                        Coordinator = users == null ? "No User" : users.FirstName + " " + users.LastName,
                                        Volume = ladAddressLoading.VolumeTotal,
                                        DeliveryCountry = countryDelivery.ISO2,
                                        DeliveryDate = ladAddressDelivery.From,
                                        LoadingCountry = countryLoading.ISO2,
                                        LoadingDate = ladAddressLoading.From,
                                    };
                        List<TruckList> trucks = data.Select(x => new TruckList()
                        {
                                Coordinator = x.Coordinator,
                                Volume = x.Volume,
                                Delivery = x.DeliveryCountry + " - " + x.DeliveryDate.Value.ToString("dd/MM/yyyy"),
                                Loading = x.LoadingCountry + " - " + x.LoadingDate.Value.ToString("dd/MM/yyyy"),
                        });
                        allTrucks.AddRange(trucks);
