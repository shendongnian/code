    class Tile
    {
    private:
        WallConfiguration walls;
        // Other Tile data
    public:
        enum Walls
        { 
            TOP,
            BOTTOM,
            LEFT,
            RIGHT,
            TOP_RIGHT,
            TOP_LEFT
            // Fill in the rest
        }; //Enums have a place!
        Tile(Walls wall)
        {
            walls = WallFactory.getConfiguration(wall);
        }
