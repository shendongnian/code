    var notSureWhyStringBuilder = new StringBuilder();
    foreach (var val in myList)
    {
        if (val is IEnumerable enumeration)
        {
            foreach (var innerEnumeration in enumeration)
            {
                notSureWhyStringBuilder.Append($",{innerEnumeration.ToString()}");
            }
        }
    }
    Console.WriteLine(notSureWhyStringBuilder.ToString());
