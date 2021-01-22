    //absract, no one can create me
    public abstract class Room
    {
        protected static List<Room> createdRooms = new List<Room>();
    
        //returns a room if a room of its type is already created
        protected static T GetAlreadyCreatedRoom<T>() where T : Room
        {
            return createdRooms.Find(x => x.GetType() == typeof (T)) as T;
        }
    }
    
    public class WickedRoom : Room
    {
        //private ctor, no-one can create me, but me!
        private WickedRoom()
        {
        }
    
        public static WickedRoom GetWickedRoom()
        {
            WickedRoom result = GetAlreadyCreatedRoom<WickedRoom>();
    
            if (result == null)
            {
                //create a room, and store
                result = new WickedRoom();
                createdRooms.Add(result);
            }
    
            return result;
        }
    }
    
    
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Can't do this as wont compile
            //WickedRoom room = new WickedRoom();
    
            //have to use the factory method:
            WickedRoom room1 = WickedRoom.GetWickedRoom();
            WickedRoom room2 = WickedRoom.GetWickedRoom();
    
            //actually the same room
            Debug.Assert(room1 == room2);
        }
    }
