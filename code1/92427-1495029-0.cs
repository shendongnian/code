    public class FuelConstants<T>
    {
        public T C_percentage;
        public T H_percentage;
        public T O_percentage;
        public T N_percentage;
        public T S_percentage;
        public FuelConstants<T>()
        {
            if (typeof(T) == typeof(int))
            {
                // cast via object is needed because from compiler's POV,
                // T and int are still unrelated types...
                C_percentage = (T)(object)123;
                H_percentage = (T)(object)456;
            }
            else if (typeof(T) == typeof(decimal))
            ...
        }
    };
