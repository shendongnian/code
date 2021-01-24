    //Given an input of "bmW" in whatever casing for "make"
    var input = "bmW";
    
    //myCars.Where(c => c.Make.ToLower() == input.ToLower()).ToList().ForEach(r => Console.WriteLine("VIN: {0} Model {1}, Price {2}, Year {3}", r.VIN, r.Model, r.StickerPrice, r.Year));
    //was being too lazy, and based on @JohnWu's comment, interesting read and comments...:
    myCars.Where(c => String.Equals(c.Make, input, StringComparison.OrdinalIgnoreCase)).ToList().ForEach(r => Console.WriteLine("VIN: {0} Model {1}, Price {2}, Year {3}", r.VIN, r.Model, r.StickerPrice, r.Year));
