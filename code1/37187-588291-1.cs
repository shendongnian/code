    //abstract, no one can create me
    public abstract class Room
    {
        protected static List<Room> createdRooms = new List<Room>();
        private static List<Type> createdTypes = new List<Type>();
    
        //bass class ctor will throw an exception if the type is already created
        protected Room(Type RoomCreated)
        {
            //confirm this type has not been created already
            if (createdTypes.Exists(x => x == RoomCreated))
                throw new Exception("Can't create another type of " + RoomCreated.Name);
            createdTypes.Add(RoomCreated);
        }
    
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
            : base(typeof(WickedRoom)) //forced to call down to the abstract ctor
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
    
    public class NaughtyRoom :Room
    {
        //allows direct creation but forced to call down anyway
        public NaughtyRoom() : base(typeof(NaughtyRoom))
        {
            
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
            
            NaughtyRoom room3 = new NaughtyRoom(); //Allowed, just this once!
            NaughtyRoom room4 = new NaughtyRoom(); //exception, can't create another
        }
    }
