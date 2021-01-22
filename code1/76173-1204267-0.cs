    List<int> lstMin = new List<int>();
    int Min = 1;
    int Max = 1500;
    int Length = Max - Min;
    int Current = Min;
    int ConnectedClient = 7;
    double Space;
    while(ConnectedClient > 0)
    {
        Space = Math.Ceiling((double)(Length * ConnectedClient / (Max - Min)));
        Current += (int)Space;
        ConnectedClient--;
        Length--;
        lstMin.Add(Current);
    }
