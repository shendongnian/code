    using System;
    using System.Collections.Generic;
    
    public class ReadOnly<VT>
      where VT : struct
    {
      private VT value;
      public ReadOnly(VT value)
      {
        this.value = value;
      }
      public static implicit operator VT(ReadOnly<VT> rvalue)
      {
        return rvalue.value;
      }
      public static explicit operator ReadOnly<VT>(VT rvalue)
      {
        return new ReadOnly<VT>(rvalue);
      }
    }
    
    public static class TestFunctionArguments
    {
      static void TestCall()
      {
        long a = 0;
        
        // CALL USAGE 1.
        // explicite cast must exist in call to this function
        // and clearly states it will be readonly inside TestCalled function.
        TestCalled(a);                  // invalid call, we must explicit cast to ReadOnly<T>
        TestCalled((ReadOnly<long>)a);  // explicit cast to ReadOnly<T>
    
        // CALL USAGE 2.
        // Debug vs Release call has no difference - no compiler errors
        TestCalled2(a);
    
      }
    
      // ARG USAGE 1.
      static void TestCalled(ReadOnly<long> a)
      {
        // invalid operations, compiler errors
        a = 10L;
        a += 2L;
        a -= 2L;
        a *= 2L;
        a /= 2L;
        a++;
        a--;
        // valid operations
        long l;
        l = a + 2;
        l = a - 2;
        l = a * 2;
        l = a / 2;
        l = a ^ 2;
        l = a | 2;
        l = a & 2;
        l = a << 2;
        l = a >> 2;
        l = ~a;
      }
    
    
      // ARG USAGE 2.
    #if DEBUG
      static void TestCalled2(long a2_writable)
      {
        ReadOnly<long> a = new ReadOnly<long>(a2_writable);
    #else
      static void TestCalled2(long a)
      {
    #endif
        // invalid operations
        // compiler will have errors in debug configuration
        // compiler will compile in release
        a = 10L;
        a += 2L;
        a -= 2L;
        a *= 2L;
        a /= 2L;
        a++;
        a--;
        // valid operations
        // compiler will compile in both, debug and release configurations
        long l;
        l = a + 2;
        l = a - 2;
        l = a * 2;
        l = a / 2;
        l = a ^ 2;
        l = a | 2;
        l = a & 2;
        l = a << 2;
        l = a >> 2;
        l = ~a;
      }
    
    }
