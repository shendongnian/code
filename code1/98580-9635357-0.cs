    public class TestableSingleton : SingletonClass
    {
      public TestableSingleton ()
      {
        FieldInfo fieldInfo = typeof(SingletonClass)
            .GetField("_instance",
            BindingFlags.Static | BindingFlags.NonPublic);
        fieldInfo.SetValue(Instance, this);
      }
    }
