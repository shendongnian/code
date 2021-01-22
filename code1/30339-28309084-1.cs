    enum ExampleEnum
    {
        Demo = 0,
        Test = 1, 
        Live = 2
    }
...
    ExampleEnum ee = ExampleEnum.Live;
    Console.WriteLine(ee.ToFriendlyString());
