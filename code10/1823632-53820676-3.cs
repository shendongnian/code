    class Item
    {
        public float Value { get; set; }
        public float Step { get; set; }
    }
    static void Main()
    {
        var testItems = new List<Item>
        {
            new Item {Value = 1038, Step = 5},
            new Item {Value = .8f, Step = .25f},
            new Item {Value = .9f, Step = .25f},
            new Item {Value = -86, Step = -45},
        };
        foreach (var testItem in testItems)
        {
            Console.WriteLine("The closest number to {0} when stepping by {1} is {2}", 
                testItem.Value, testItem.Step, GetClosestNumber(testItem.Value, testItem.Step));
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
