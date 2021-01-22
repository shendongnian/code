    class Car
    {
        public static int TyreCount = 4;
        public virtual int GetTyreCount() { return TyreCount; }
    }
    class Tricar : Car
    {
        public static new int TyreCount = 3;
        public override int GetTyreCount() { return TyreCount; }
    }
    ...
    Car[] cc = new Car[] { new Tricar(), new Car() };
    int t0 = cc[0].GetTyreCount(); // t0 == 3
    int t1 = cc[1].GetTyreCount(); // t1 == 4
