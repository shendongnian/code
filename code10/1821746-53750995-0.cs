    using System.Linq;
    // ...
    var listNumbers = System.IO.File
        .ReadAllLines("Numbers.txt")
        .Take(125)
        .ToList();
