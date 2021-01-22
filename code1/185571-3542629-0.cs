    public static class ModelObjectFactory
    {
        public static ModelObject GetModel<T>(T obj)
        {
            // return ModelObject according to type of parameter
        }
    }
    
    class Child
    {
        public Child()
        {
            ModelObject mo = ModelObjectFactory(this);
            this.someField = mo.someField;
        }
    }
