    public class Store {
        public BaseModel SomeMethod<T>(T model)
            where T : BaseModel
        {
            string name = model.Name;
            string namePlural = model.NamePlural;
            ...
        }
    }
