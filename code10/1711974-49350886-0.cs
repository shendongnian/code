    //(For this example you should have a class defined which has the properties of the parking positions, and one for the aircraft. Here I've used Gate and Plane respectively.)
    //This is a list of the Gate object. Contains every gate and the properties about them.
    var Gates = List<Gate>;
    Plane aircraft;
    //This will find spaces compatible with the supplied aircraft
    IEnumerable<Gate> usableGates= Gates.Where(gate => gate.SupportedSize==aircraft.Size && gate.International==aircraft.International && gate.Terminal==aircraft.Terminal);
    //Now any items which appear in usableGates should be usable for that aircraft
