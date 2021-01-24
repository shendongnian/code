    public class Test
    {
        public string Name { get; set; }
    }
    List<Test> list1 = new List<Test>();
    list1.Add(new Test() { Name = "John" });
    List<Test> list2 = list1.ToList();
    Console.WriteLine(list1[0].Name); // John
    Console.WriteLine(list2[0].Name); // John
    list2[0].Name = "Fred";
    Console.WriteLine(list1[0].Name); // Fred
    Console.WriteLine(list2[0].Name); // Fred
