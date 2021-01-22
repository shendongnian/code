    class Piece 
    {
        Image Render(Rectangle bounds) { /*  */ }
    }
    
    class Board
    {
        void Render(Graphics g)
        {
            //Draw the base
            foreach (piece in Pieces)
            {
                var rect = figureOutPosition(); //Positioning logic to 
                g.DrawImage(location, rect, piece.Render(rect));
            }
            //Draw any overlays
        }
    }
