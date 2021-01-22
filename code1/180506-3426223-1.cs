    public class B : A
    {
    	private static readonly DynamicMethod GRANDPARENT_GET_HASH_CODE;
    	static B()
    	{
    	    MethodInfo gpGHC = typeof(object).GetMethod("GetHashCode", BindingFlags.Public | BindingFlags.Instance);
    	    
    	    GRANDPARENT_GET_HASH_CODE = new DynamicMethod("grandParentGHC", typeof(int), new Type[] { typeof(object) }, typeof(object));
    	    ILGenerator il = GRANDPARENT_GET_HASH_CODE.GetILGenerator();
    	    il.Emit(OpCodes.Ldarg, 0);
    	    il.EmitCall(OpCodes.Call, gpGHC, null);
    	    il.Emit(OpCodes.Ret);
    	}
        private int num;
        public B()
        {
            num = 0;
        }
        public B(int x)
        {
            num = x;
        }
    	public override int GetHashCode()
    	{
    	    return num + (int)GRANDPARENT_GET_HASH_CODE.Invoke(null, new object[]{this});
    	}
    }
