        // slow; use with caution
        public static Result<T> Generic<T>(T arg) {
            if (typeof(T).IsValueType)
                return (Result<T>)typeof(Program).GetMethod("ImplVal")
                    .MakeGenericMethod(typeof(T))
                    .Invoke(null, new object[] {arg});
            else
                return (Result<T>)typeof(Program).GetMethod("ImplRef")
                    .MakeGenericMethod(typeof(T))
                    .Invoke(null, new object[] { arg });
        }
