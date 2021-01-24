    ...
    ClosedDate = FlowerDates.FirstOrDefault(c =>string[] {"Rainbow Rose", 
                                                          "Black Rose",
                                                          "SunFlower",
                                                          "Lotus",
                                                          "Tulip",
                                                          "Rose"}.Contains( c.FlowerType));
