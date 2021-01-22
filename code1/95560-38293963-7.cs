    string[] result;
    // Pass a string, and the delimiter
    result = string.Split("My simple string", " ");
    // Split an existing string by delimiter only
    string foo = "my - string - i - want - split";
    result = foo.Split("-");
    // You can even pass the split options parameter. When omitted it is
    // set to StringSplitOptions.None
    result = foo.Split("-", StringSplitOptions.RemoveEmptyEntries);
