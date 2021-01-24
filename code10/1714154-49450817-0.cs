    public class BaseParamsClass
    {
        public virtual void SetParam(int pBaseParam)
        {
            baseParam = 0;
        }
        public int baseParam;
    }
    public class Parent1ParamsClass : BaseParamsClass
    {
        public override void SetParam(int pBaseParam)
        {
            base.SetParam(pBaseParam);
            //do other stuff specific to this class...
        }
        public int parentParam1;
    }
    public class Parent2ParamsClass : BaseParamsClass
    {
        public override void SetParam(int pBaseParam)
        {
            base.SetParam(pBaseParam);
            //do other stuff specific to this class...
        }
        public int parentParam2;
    }
    public delegate void GenericCallback<T>(T theParams) where T : BaseParamsClass, new();
    private IEnumerator GenericCorFunction<T>(GenericCallback<T> callback) where T:BaseParamsClass, new()
    {
        // This demonstrate few actions i do before the call
        yield return new WaitForSeconds(1);
        // Now i get the result, it can be 0-10, each one should activate different callback
        int result = 0;
        //I assume you want result here.
        //Also note that you can't use the constructor to set the base param as at compile time
        //we're not sure which type will be being used.  There are ways around this but it's
        //probably clearer to use basic constructor then call the SetParam virtual/overridden method            
        var param = new T();
        param.SetParam(result);
        callback(param);
    }
