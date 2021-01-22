    public static class MyExtensions{
        public static bool HasAandB(this thing t){
            return t.propA.HasValue && t.propB.HasValue;
        }
    }
