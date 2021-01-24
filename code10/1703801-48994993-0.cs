    class StringWrapper
    {
        public string Value { get; set; }
    }
    private static void Main()
    {
        StringWrapper str1 = new StringWrapper {Value = null};
        StringWrapper str2 = new StringWrapper {Value = null};
        var arr1 = new[] { str1, str2 }; // pass by reference
        var arr2 = new[] {new StringWrapper {Value =  "value1"}, new StringWrapper { Value = "value2" }};
        for (int i = 0; i < arr2.Count(); i++)
            arr1[i].Value = arr2[i].Value; // assign new value
        Console.WriteLine($"{str1.Value} {str2.Value}");
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
