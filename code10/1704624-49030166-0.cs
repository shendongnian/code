    public interface IDbObject
    {
        IDbObject ParentObject
        {
            get;
        }
    }
    public abstract class IDbConstraint : IDbObject
    {
        public IDbObject ParentTable 
        {
            get;
        }
        //Hidden becouse not public
        IDbObject IDbObject.ParentObject => throw new NotImplementedException();
    }
