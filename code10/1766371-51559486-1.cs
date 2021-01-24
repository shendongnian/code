    //...  
    // Adding button to the array
    tiles25[count] = new Button()
    {
        Size = new Size(24, 24),
        Location = new Point(x, y),
    };
    tiles25[count] += new EventHandler(this.Tile_Click);
    //...
    void Tile_Click(Object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        //...
    }
