    public class SomeClass
    {
        public object thing;
        public string ObjectToString(Context context)
        {
            if (thing is IDynamicValue<object>)
            {
                return (thing as IDynamicValue<object>).Get(context).ToString();
            }
            if (thing is IDynamicValue)
            {
                return (thing as IDynamicValue).Get(context).ToString();
            }
            return thing.ToString();
        }
    }
