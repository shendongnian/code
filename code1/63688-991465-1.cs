    static unsafe List<A> CastBasAIL(List<B> bIn) {
    
      DynamicMethod dynamicMethod = new DynamicMethod("foo1", typeof(List<A>), 
       new[] { typeof(List<B>) }, typeof(void));
      ILGenerator il = dynamicMethod.GetILGenerator();
      il.Emit(OpCodes.Ldarg_0);                     // copy first argument  to stack
      il.Emit(OpCodes.Ret);                         // return the item on the stack
      CCastDelegate HopeThisWorks = (CCastDelegate)dynamicMethod.CreateDelegate(
       typeof(CCastDelegate));
    
      return HopeThisWorks(bIn);
    
    }
