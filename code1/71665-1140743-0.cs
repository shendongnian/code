    public class Repository<T> : IRepository<T> where T : Model, new()
    {
        // ...
        private delegate T CtorDelegate();
        private CtorDelegate _constructor = null;
        private CtorDelegate Constructor
        {
            get
            {
                if (_constructor == null)
                {
                    Type type = typeof(T);
                    DynamicMethod dm = new DynamicMethod(type.Name + "Constructor", type, new Type[] { }, typeof(Repository<T>).Module);
                    ILGenerator ilgen = dm.GetILGenerator();
                    ilgen.Emit(OpCodes.Nop);
                    ilgen.Emit(OpCodes.Newobj, type.GetConstructor(Type.EmptyTypes));
                    ilgen.Emit(OpCodes.Ret);
                    _constructor = (CtorDelegate)dm.CreateDelegate(typeof(CtorDelegate));
                }
                return _constructor;
            }
        }
        public T FromData(DataTable table, DataRow row)
        {
            T model = Constructor(); // was previously = new T();
            model.Init(table, row);
            return model;
        }
    }
