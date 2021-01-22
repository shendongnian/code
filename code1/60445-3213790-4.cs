    enum Sides {
        Left, Right, Top, Bottom
    }
    Sides side = Sides.Bottom;
    object val = Convert.ChangeType(side, side.GetTypeCode());
    Console.WriteLine(val);
