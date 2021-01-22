    abstract class GenericGameObject<TModel>
        where TModel : DefaultGameObjectModel
    {
         private TModel model;
         // Or whatever
         public TModel Model
         {
             get { return model; }
             protected set { model = value; }
         }
    }
