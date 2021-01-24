    public class ShapeClass
            {
                public void paintRectangle(DrawArgs drawArgs)
                {
                    //w1 = Convert.ToDouble((Convert.ToInt32(f1.ShapeWidth()) * 96) / 25.4);
                    //h1 = Convert.ToDouble((Convert.ToInt32(f1.ShapeHeight()) * 96) / 25.4);
                    //x = ((484 / 2) - (Convert.ToInt32(w1) / 2));
                    //y = ((484 / 2) - (Convert.ToInt32(h1) / 2));
                    // get your params
                    var x = drawArgs.x;
                    var y = drawArgs.y;
                    var w1 = drawArgs.width;
                    var h1 = drawArgs.height;
                    
                    Pen red = new Pen(Color.Red, 3);
                    Rectangle rect = new Rectangle(x, y, Convert.ToInt32(w1), Convert.ToInt32(h1));
                    drawArgs.e.Graphics.DrawRectangle(red, rect);
                }
            }
