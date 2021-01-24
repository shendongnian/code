    // you don't necessarily need this interface but it allows a meaningful
    // constraint if you apply it to your 'entity' classes. If you can't apply
    // this interface to the entity classes then remove the constraints below
    public interface IEntity
    {
        // things it does
    }
    public class XEntity : IEntity
    {
    }
    public class YEntity : IEntity
    {
    }
    public interface IConsumer<TEntity> where TEntity : IEntity // remove constraint if required
    {
        TEntity Consume(Stream stream, out List<Error> errors);
    }
    public class XConsumer : IConsumer<XEntity>
    {
        public XEntity Consume(Stream stream, out List<Error> errors);
        {
            // something
        }
    }
    public class YConsumer : IConsumer<YEntity>
    {
        public YEntity Consume(Stream stream, out List<Error> errors);
        {
            // something
        }
    }
    
    public static class ConsumerFactory
    {
        // this will now create a consumer instance based on the entity type
        public static IConsumer<TEntity> Create<TEntity>() where TEntity : IEntity // remove constraint if required
        {
            if (typeof(TEntity) == typeof(XEntity))
                return new XConsumer;
            if (typeof(TEntity) == typeof(YEntity))
                return new YConsumer;
            throw new Exception("Unsupported type");
        }
        public static TEntity Consume<TEntity>(Stream stream, out List<Error> errors) where TEntity : IEntity // remove constraint if required
        {
            return Create<TEntity>().Consume(stream, out errors);
        }
    }
