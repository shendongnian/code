    //let's assume this is the type that GetAddResult method is returning.
    public class MyAddResult { ... }
    //let's say this is what method TransformResult is returning.
    public class MyTransformResult { ... }
    public static class MyFlow {
        public static MyTransformResult TransformResult(this MyAddResult src) {
            ....
        }
        
        public static void IfValid(this MyTransformResult src, Action<MyTransformResult> methodIfTrue, Action<MyTransformResult> methodIfFalse) {
            if( CheckValidity(src) )
              methodIfTrue(src);
            
            methodIfFalse(src);
        }
    }
    //In another place
    public void SendResult(MyTransformResult m) { ... }
    //In another place
    public void LogError(MyTransformResult m) { ... }
