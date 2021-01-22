    static class GadgetFactory
    {
        public static IMainInterface GetGadget(string className)
        {
             (IMainInterface)Activator.CreateInstance(Type.GetType(className))
        }
    }
