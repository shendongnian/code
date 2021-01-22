    public abstract class ReallyBaseType
    {
        public abstract void SomeMethod();
        public abstract void SomeMethodWithParameter(object o);
    }
    public abstract class BaseType<TEntity> : ReallyBaseType
        where TEntity : BaseType<TEntity>
    {
        public override void SomeMethodWithParameter(object o)
        {
            SomeMethodWithParameter((TEntity)o);
        }
        public abstract void SomeMethodWithParameter(TEntity entity);
    }
    public class AnyType : BaseType<AnyType>
    {
        public override void SomeMethod() { }
        public override void SomeMethodWithParameter(AnyType entity) { }
    }
