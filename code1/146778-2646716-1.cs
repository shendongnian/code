    // define a class to help us manage our grid
    public class GridItem {
        public Rectangle Bounds {get; set;}
        public Brush Fill {get; set;}
    }
    
    // somewhere in your initialization code ie: the form's constructor
    public MyForm() {
        // create your collection of grid items
        gridItems = new List<GridItem>(4 * 10); // width * height
        for (int y = 0; y < 10; y++) {
            for (int x = 0; x < 4; x++) {
                gridItems.Add(new GridItem() {
                    Bounds = new Rectangle(x * boxWidth, y * boxHeight, boxWidth, boxHeight),
                    Fill = Brushes.Red // or whatever color you want
                });
            }
        }
    }
    
    // make sure you've attached this to your pictureBox's Paint event
    private void PictureBoxPaint(object sender, PaintEventArgs e) {
        // paint all your grid items
        foreach (GridItem item in gridItems) {
            e.Graphics.FillRectangle(item.Fill, item.Bounds);
        }
    }
    // now if you want to change the color of a box
    private void OnClickBlue(object sender, EventArgs e) {
        // if you need to set a certain box at row,column use:
        // index = column + row * 4
        gridItems[2].Fill = Brushes.Blue; 
        pictureBox.Invalidate(); // we need to repaint the picturebox
    }
