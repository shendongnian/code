    public static class Extensions {
        public static string GetName(this Delegate funcPtr) {
            return funcPtr.Method.Name;
        }
    }
