    generic <typename T>
    where T : value class
    public ref struct Reinterpret
    {
        private:
        const static int size = sizeof(T);
        public:    
        static int AsInt(T t)
        {
            return *((Int32*) (void*) (&t));
        }
    }
