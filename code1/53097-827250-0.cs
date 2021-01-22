    class Test<T> where T : class {
        public void Method<U>(U val) {
            Console.WriteLine(typeof(U).FullName);
        }
    }
