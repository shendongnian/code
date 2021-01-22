        dynamic x = new System.Web.Helpers.DynamicJsonObject(new ExpandoObject());
        x.a = 1;
        x.b = 2.50;
        Console.WriteLine("a is " + (x.a ?? "undefined"));
        Console.WriteLine("b is " + (x.b ?? "undefined"));
        Console.WriteLine("c is " + (x.c ?? "undefined"));
