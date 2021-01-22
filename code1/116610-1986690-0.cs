    public abstract class Room
    {
    public void Connect(Room r)
    {
    this.ConnectedRooms.Add(r);
    r.ConnectedRooms.Add(this);
    }
    }
