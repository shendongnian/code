    public static class MyCachedData<T>{
        static readonly CachedData Value;
        static MyCachedData(){
           Value=// Heavy computation, such as baking IL code or doing lots of reflection on a type
        }
    }
