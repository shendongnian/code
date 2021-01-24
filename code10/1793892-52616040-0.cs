                var country = new MyCountry {
                    Title ="Syria",
                    ShortName="SYR",
                     Translations=new[]
                     {
                         new CountryTranslate { LCID=1, Name="سوريا" },
                         new CountryTranslate { LCID=31, Name="Suriye" },
                         new CountryTranslate {LCID=9, Name="Syria" }
                     },
                      Cities=new[]
                      {
                          new MyCity
                          {
                              Title="Lattakia",
                              ShortName = "LAT",
                              Translations=new[]
                              {
                                  new CityTranslate { LCID=1, Name="اللاذقية" },
                                  new CityTranslate {LCID=31, Name="Lazkiye" },
                                  new CityTranslate {LCID=9, Name="Lattakia" }
                              },
                              Districts=new[]
                              {
                                  new MyDistrict
                                  {
                                      Title="Owineh",
                                      Translations=new[]
                                      {
                                          new DistrictTranslate { LCID=1, Name="العوينة" },
                                          new DistrictTranslate { LCID=31, Name="Uveyne" },
                                          new DistrictTranslate {LCID=9, Name="Owineh" }
                                      },
                                      Neighborhoods = new[]
                                      {
                                          new MyNeighborhood
                                          {
                                              Title="Reji",
                                              Translations = new[]
                                              {
                                                  new NeighborhoodTranslate { LCID=1, Name="الريجي"},
                                                  new NeighborhoodTranslate { LCID=31, Name="Eski Reji"},
                                                  new NeighborhoodTranslate { LCID=9, Name="Old Reji"}
                                              }
                                          }
                                      }
                                  }
                              }
                          }
                      }
                }
    context.SaveChanges();
