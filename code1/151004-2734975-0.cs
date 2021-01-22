    public abstract class EntityBase : IEquatable<EntityBase>
    {
        public EntityBase() { }
        #region IEquatable<EntityBase> Members
        public bool Equals(EntityBase other)
        {
            //Generic implementation of equality using reflection on derived class instance.
            return true;
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as EntityBase);
        }
        #endregion
    }
    public class Author : EntityBase
    {
        public Author() { }
    }
    public class Book : EntityBase
    {
        public Book() { }
    }
