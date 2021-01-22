    public class Shape : IDrawingObject, IShape
    {
        // Create an event for each interface event
        event EventHandler PreDrawEvent;
        event EventHandler PostDrawEvent;
    
        event EventHandler IDrawingObject.OnDraw
        {
            add { PreDrawEvent += value; }
            remove { PreDrawEvent -= value; }
        }
    }
