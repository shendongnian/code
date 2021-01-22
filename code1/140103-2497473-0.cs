    public void Move(int xAmount, int yAmount)
    {
       var newPosition = new Point(this.Position.X + xAmount, this.Position.Y + yAmount);
       this.Position = newPosition;
    }
