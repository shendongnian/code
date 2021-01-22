    enum Sides {
         Left, Right, Top, Bottom
    }
    Sides side = Sides.Bottom;
    
    var val = Convert.ChangeType(side, side.GetTypeCode()) ;
    Console.WriteLine(val);
