    using System;   
    using System.Collections;
    public class CastingBenchmark   
    {
        static Int64 Iterations=100000000;
        static Int64 TestWork = 0;
        public static void Init(string[] args)
        {
            if (args.Length>0)
                Iterations = Int64.Parse(args[0]);
        }
    
        public static void Reset()
        {
            TestWork = 0;
        }
        internal class BaseType { public void TestBaseMethod() { TestWork++; } }
  
        internal class DerivedType : BaseType { 
            public void TestDerivedMethod() { TestWork++; }
            public void TestDerivedMethod2() { TestWork++; }
            public void TestDerivedMethod3() { TestWork++; } 
    }
    [Benchmark]
    public static void TestMuliCast_3x()
    {
        BaseType TestBaseType = new DerivedType();
        for (int x = 0; x < Iterations; x++)
        {
            ((DerivedType)TestBaseType).TestDerivedMethod();
            ((DerivedType)TestBaseType).TestDerivedMethod2();
            ((DerivedType)TestBaseType).TestDerivedMethod3();
        }
    }
    [Benchmark]
    public static void TestSingleCast_3x()
    {
        BaseType TestBaseType = new DerivedType();
        for (int x = 0; x < Iterations; x++)
        {
            DerivedType TestDerivedType = (DerivedType)TestBaseType;
            TestDerivedType.TestDerivedMethod();
            TestDerivedType.TestDerivedMethod2();
            TestDerivedType.TestDerivedMethod3();
        }
    }
    [Benchmark]
    public static void TestMuliCast_30x()
    {
        BaseType TestBaseType = new DerivedType();
        for (int x = 0; x < Iterations; x++)
        {
            //Simulate 3 x 10 method calls while casting
            for (int y = 0; y < 10; y++) {
                ((DerivedType)TestBaseType).TestDerivedMethod();
                ((DerivedType)TestBaseType).TestDerivedMethod2();
                ((DerivedType)TestBaseType).TestDerivedMethod3();
            }
        }
    }
    [Benchmark]
    public static void TestSingleCast_30x()
    {
        BaseType TestBaseType = new DerivedType();
        for (int x = 0; x < Iterations; x++)
        {
            DerivedType TestDerivedType = (DerivedType)TestBaseType;
            
            //Simulate 3 x 10 method calls on already-cast object
            for (int y = 0; y < 10; y++)
            {
                TestDerivedType.TestDerivedMethod();
                TestDerivedType.TestDerivedMethod2();
                TestDerivedType.TestDerivedMethod3();
            }
        }
    }
        [Benchmark]
        public static void TestEmptyLoop()
        {
            for (int x = 0; x < Iterations; x++)
            {
            }
        }
        [Benchmark]
        public static void TestDCast_castclass()
        {
            BaseType TestDerivedType = new DerivedType();
            for (int x = 0; x < Iterations; x++)
            {
                ((DerivedType)TestDerivedType).TestDerivedMethod();
            }    
        }
        [Benchmark]
        public static void TestDCast_isinst()
        {
            BaseType TestDerivedType = new DerivedType();
            for (int x = 0; x < Iterations; x++)
            {
                (TestDerivedType as DerivedType).TestDerivedMethod();
            }
        }
    }
