    public interface ISomeEntity
    {
        
    }
    public class EntityFactory
    {
        public ISomeEntity CreateObject(string name)
        {
            //Do factory stuff here
            return null;
        }
    }
    public class ADisplayEntity : ISomeEntity
    {
    }
    public class BDisplayEntity : ISomeEntity
    {
    }
    public interface IDisplay
    {
        ISomeEntity Display(ISomeEntity entity);
    }
    public class ADisplay : IDisplay
    {
        public ISomeEntity Display(ISomeEntity entity)
        {
            ADisplayEntity aEntity = entity as ADisplayEntity;
            if (aEntity == null)
                throw new ArgumentException("Wrong type");
            //Do whatever happens when you convert parameter entity into a
            //"response" ADisplayEntity. I'm just returning a new 
            //ADisplayEntity to make it compile for me
            return new ADisplayEntity();
        }
    }
    public class BDisplay : IDisplay
    {
        public ISomeEntity Display(ISomeEntity entity)
        {
            BDisplayEntity bEntity = entity as BDisplayEntity;
            if (bEntity == null)
                throw new ArgumentException("Wrong type");
            //Do whatever happens when you convert parameter entity into a
            //"response" BDisplayEntity. I'm just returning a new 
            //BDisplayEntity to make it compile for me
            return new BDisplayEntity();
        }
    }
    public class Displayer
    {
        private IDictionary<Type, IDisplay> displayers;
        private EntityFactory factory;
        public Displayer()
        {
            factory = new EntityFactory();
            displayers = new Dictionary<Type, IDisplay>
                            {
                                { typeof(ADisplayEntity), new ADisplay() },
                                { typeof(BDisplayEntity), new BDisplay() }
                            };
        }
        public T Display<T>() where T : class, ISomeEntity
        {
            T entity = factory.CreateObject((typeof(T).Name)) as T; //Type-safe because of the factory
            IDisplay displayer = displayers[typeof(T)];
            return displayer.Display(entity) as T; //Typesafe thanks to each IDisplay returning the correct type
        }
    }
