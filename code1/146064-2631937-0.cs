    class myLabel : Label
    {
        protected override void InitLayout()
        {
            base.InitLayout();
            Location = new Point(Location.X, Location.Y + Height);                
        }
    }
