    //Your code
    Website website = new Website();
    var websites = website.ToDictionary<int>();
    //After compilation.
    Website website = new Website();
    var websites = EnumExtensions.ToDictionary<int>(website);
