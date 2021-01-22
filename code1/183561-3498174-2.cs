    public class IdExtender 
    {
        public static Object Extend(object toExtend)
        {
            var dyn = new DynamicObject(toExtend);
            dyn.MixWith(new WithId {
                                    Id = Guid.New()
                                   });
            var extended = dyn.CreateDuck<IWithId>(returnValue.GetType().GetInterfaces());
            return extended;
        }
    }
