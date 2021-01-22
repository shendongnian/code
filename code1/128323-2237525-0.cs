    class Ship
    {
        ShipUnit[] shipUnits;
        string type;
        public Ship(int length, string type)
        {
            shipUnits = new ShipUnit[length];
            this.type = type;
        }
    }
    
    Ship[] fleet = new Ship[5];
    fleet[0] = new Ship(5, "Carrier");
    fleet[1] = new Ship(4, "Battleship");
    fleet[2] = new Ship(3, "Submarine");
    fleet[3] = new Ship(3, "Something else");
    fleet[4] = new Ship(2, "Destroyer");
