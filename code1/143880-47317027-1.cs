    class C
    {
        public class D<D1, D2>
        {
            public class E
            {
                public class K<R1, R2, R3>
                {
                    public class P<P1>
                    {
                        public struct Q
                        {
                        }
                    }
                }
            }
        }
    }
    type = typeof(List<Dictionary<string[], C.D<byte, short[,]>.E.K<List<int>[,][], Action<List<long[][][,]>[], double[][,]>, float>.P<string>.Q>>[][,][,,,][][,,]);
    // Returns "System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String[],Test.Program.C.D<System.Byte,System.Int16[,]>.E.K<System.Collections.Generic.List<System.Int32>[,][],System.Action<System.Collections.Generic.List<System.Int64[][][,]>[],System.Double[][,]>,System.Single>.P<System.String>.Q>>[][,][,,,][][,,]":
    GetTypeCSharpRepresentation(type);
