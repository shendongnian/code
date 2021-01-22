     var a = "This is a string";
     var b = a;
     a += ". And some part is added";   // a now references another string in memory
     var aSB = new StringBuilder("This is a string");
     var bSB = aSB
     aSB.Append(". And some part is added"); // aSB and bSB still reference the same memory spot
     Console.WriteLine(b);   // ==> This is a string
     Console.WriteLine(bSB); // ==> This is a string. And some part is added
