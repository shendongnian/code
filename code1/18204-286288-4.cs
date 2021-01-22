    public class A
    {
        public IFieldSimpleItem Create()
        {
            IFieldSimpleItem created = InternalCreate();
            CheckCreatedType(created);
            return created;
        }
        protected virtual IFieldSimpleItem InternalCreate()
        {
            return new SimpleImpl();
        }
        protected virtual void CheckCreatedType(IFieldSimpleItem item)
        { 
            // base class doesn't care. compiler guarantees IFieldSimpleItem
        }
    }
    public class B : A
    {
        protected override IFieldSimpleItem InternalCreate()
        {
            // does not call base class.
            return new NormalImpl();
        }
        protected override void CheckCreatedType(IFieldSimpleItem item)
        {
            base.CheckCreatedType(item);
            if (!(item is IFieldNormalItem))
                throw new Exception("I need a normal item.");
        }
    }
