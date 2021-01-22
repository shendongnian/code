    public abstract DrawableEvent
    {
        Event event;
        IDrawingStrategy drawingstrategy;
        public Draw()
        {   
            drawingStrategy.Draw();
        }
    }
    public SportingEvent1 : DrawableEvent
    {
        SprortingEvent1(Event event, IdrawingStrategy strategy)
        {
             this.Event=event;
             this.drawingstrategy = strategy;
        }
    }
