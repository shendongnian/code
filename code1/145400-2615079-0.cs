    public delegate void Drawer(int x, int y, Tile tile);
    public void Draw(Drawer drawer, bool[,] map, Tile[,] tiles) {
        for (int x = 0; x < this.Size.Width; x++) {
            for (int y = 0; y < this.Size.Height; y++) {
                if (this.Map[x, y]) {
                    drawer(x, y, tiles[x, y]);
                }
            }
        }
    }
