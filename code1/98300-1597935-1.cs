    public static class Guard {
        public static void ArgumentIsNotNull(object value, string argument) {
            if (value == null)
                throw new ArgumentNullException(argument);
        }
    }
