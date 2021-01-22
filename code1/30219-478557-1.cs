    // Test cases for FoldMapUCase.fs
    //
    // For this example, I have written my NUnit test cases in C#.  This requires constructing some F#
    // types in order to invoke the F# functions under test.
    
    
    using System;
    using Microsoft.FSharp.Core;
    using Microsoft.FSharp.Collections;
    using NUnit.Framework;
    
    namespace FoldMapUCase
    {
        [TestFixture]
        public class TestFoldMapUCase
        {
            public TestFoldMapUCase()
            {            
            }
    
            [Test]
            public void CheckAlwaysTwo()
            {
                // simple example to show how to access F# function from C#
                int n = Zumbro.AlwaysTwo;
                Assert.AreEqual(2, n);
            }
    
            class Helper<T>
            {
                public static List<T> mkList(params T[] ar)
                {
                    List<T> foo = List<T>.Nil;
                    for (int n = ar.Length - 1; n >= 0; n--)
                        foo = List<T>.Cons(ar[n], foo);
                    return foo;
                }
            }
    
    
            [Test]
            public void foldl1()
            {
                int seed = 64;
                List<int> values = Helper<int>.mkList( 4, 2, 4 );
                FastFunc<int, FastFunc<int,int>> fn =
                    FuncConvert.ToFastFunc( (Converter<int,int,int>) delegate( int a, int b ) { return a/b; } );
    
                int result = Zumbro.foldl<int, int>( fn, seed, values);
                Assert.AreEqual(2, result);
            }
    
            [Test]
            public void foldl0()
            {
                string seed = "hi mom";
                List<string> values = Helper<string>.mkList();
                FastFunc<string, FastFunc<string, string>> fn =
                    FuncConvert.ToFastFunc((Converter<string, string, string>)delegate(string a, string b) { throw new Exception("should never be invoked"); });
    
                string result = Zumbro.foldl<string, string>(fn, seed, values);
                Assert.AreEqual(seed, result);
            }
    
            [Test]
            public void map()
            {
                FastFunc<int, int> fn =
                    FuncConvert.ToFastFunc((Converter<int, int>)delegate(int a) { return a*a; });
    
                List<int> vals = Helper<int>.mkList(1, 2, 3);
                List<int> res = Zumbro.map<int, int>(fn, vals);
               
                Assert.AreEqual(res.Length, 3);
                Assert.AreEqual(1, res.Head);
                Assert.AreEqual(4, res.Tail.Head);
                Assert.AreEqual(9, res.Tail.Tail.Head);
            }
    
            [Test]
            public void ucase()
            {
                List<string> vals = Helper<string>.mkList("arnold", "BOB", "crAIg");
                List<string> exp = Helper<string>.mkList( "ARNOLD", "BOB", "CRAIG" );
                List<string> res = Zumbro.ucase(vals);
                Assert.AreEqual(exp.Length, res.Length);
                Assert.AreEqual(exp.Head, res.Head);
                Assert.AreEqual(exp.Tail.Head, res.Tail.Head);
                Assert.AreEqual(exp.Tail.Tail.Head, res.Tail.Tail.Head);
            }
    
        }
    }
