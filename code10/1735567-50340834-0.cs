    Action<string> idCheckAction = (string _id) =>
    {
        Console.WriteLine("ID = " + _id);
    };
    Func<string, string> idCheckFunc = (string _id) =>
    {
        return "ID = " + _id;
    };
    idCheckAction("123"); // "ID = 123"
    string concat = idCheckFunc("123"); 
    Console.WriteLine(concat); // "ID = 123"
