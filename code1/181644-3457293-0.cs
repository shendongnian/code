     var copiedCountry = CloneObject(_package.Country);
    
    
                for (int indexOfRegion = 0; indexOfRegion < copiedCountry.ListOfRegions.Count; indexOfRegion++)
                {
                    var region = copiedCountry.ListOfRegions[indexOfRegion];
                    if (region.ListOfProvinces.Count > 0)
                    {
                        for (int indexOfProvince = 0; indexOfProvince < region.ListOfProvinces.Count; indexOfProvince++)
                        {
                            var province = region.ListOfProvinces[indexOfProvince];
                            if (province.ListOfCities.Count > 0)
                            {
                                for (int indexOfCity = 0; indexOfCity < province.ListOfCities.Count; indexOfCity++)
                                {
                                    var city = province.ListOfCities[indexOfCity];
                                    int numberOfHotels = city.ListOfHotels.Count;
                                    for (int indexOfHotel = 0; indexOfHotel < numberOfHotels; indexOfHotel++)
                                    {
                                        var hotel = city.ListOfHotels[indexOfHotel];
                                        if (hotel.userHaveBeenThere  == false)
                                        {
                                            city.ListOfHotels[indexOfHotel] = null;
                                        }
                                    }
    
                                    city.ListOfHotels.RemoveAll(h => h == null);
    
                                    if (city.ListOfHotels.Where(h => h.userHaveBeenThere  == true).Count() > 0)
                                    {
    
                                    }
                                    else
                                    {
                                        if (city.userHaveBeenThere  == false)
                                        {
                                            province.ListOfCities[indexOfCity]=null;
                                        }
    
                                    }
                                }
    
                                province.ListOfCities.RemoveAll(c => c == null);
    
                                if (province.ListOfCities.Count == 0)
                                {
                                    if (province.userHaveBeenThere  == false)
                                    {
                                        region.ListOfProvinces[indexOfProvince]=null;
                                    }
                                }
    
    
                               
                            }
                            else
                            {
                                if (province.userHaveBeenThere  == false)
                                {
                                    region.ListOfProvinces[indexOfProvince] = null;
                                }
                            }
                        }
    
                        region.ListOfProvinces.RemoveAll(p => p == null);
    
                        if (region.ListOfProvinces.Count == 0)
                        {
                            if (region.userHaveBeenThere  == false)
                            {
                                copiedCountry.ListOfRegions[indexOfRegion]=null;
                            }
                        }
                    }
                    else
                    {
                        if (region.userHaveBeenThere  == false)
                        {
                            copiedCountry.ListOfRegions[indexOfRegion]=null;
                        }
                    }
    
                    copiedCountry.ListOfRegions.RemoveAll(r => r == null);
                }
    
    
    public static T CloneObject<T>(T item)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    
                    BinaryFormatter bf = new BinaryFormatter(null,
                              new StreamingContext(StreamingContextStates.Clone));
    
                    try
                    {
                        bf.Serialize(ms, item);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
    
                  
                    ms.Seek(0, SeekOrigin.Begin);
    
                   
                    return (T)bf.Deserialize(ms);
                }
            }
