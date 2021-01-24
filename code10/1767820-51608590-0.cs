    Dictionary<Fruit, Color> FruitToColor = new Dictionary<Fruit, Color>
                                              { { Fruit.Apple, Color.Red }
                                              , { Fruit.Orange, Color.Orange }
                                              , { Fruit.Banana, Color.Yellow }
                                              };
    Color colorOfBanana = FruitToColor[Fruit.Banana]; // yields Color.Yellow
