    // Author: Salvatore Previti - 2011.
    /// <summary>We need a delegate type to our method to make this technique works.</summary>
    delegate int MyMethodDelegate(string parameter);
    /// <summary>An enum used to mark cache status for IsOverridden.</summary>
    enum OverriddenCacheStatus
    {
        Unknown,
        NotOverridden,
        Overridden
    }
    public class MyClassBase
    {
        /// <summary>Cache for IsMyMethodOverridden.</summary>
        private volatile OverriddenCacheStatus pMyMethodOverridden;
        public MyClassBase()
        {
            // Look mom, no overhead in the constructor!
        }
        /// <summary>
        /// Returns true if method MyMethod is overridden; False if not.
        /// We have an overhead the first time this function is called, but the
        /// overhead is a lot less than using reflection alone. After the first time
        /// this function is called, the operation is really fast! Yeah!
        /// This technique works better if IsMyMethodOverridden() should
        /// be called several times on the same object.
        /// </summary>
        public bool IsMyMethodOverridden()
        {
            OverriddenCacheStatus v = this.pMyMethodOverridden;
            switch (v)
            {
                case OverriddenCacheStatus.NotOverridden:
                    return false; // Value is cached! Faaast!
                case OverriddenCacheStatus.Overridden:
                    return true; // Value is cached! Faaast!
            }
            // We must rebuild cache.
            // We use a delegate: also if this operation allocates a temporary object
            // it is a lot faster than using reflection!
            // Due to "limitations" in C# compiler, we need the type of the delegate!
            MyMethodDelegate md = this.MyMethod;
            
            if (md.Method.DeclaringType == typeof(MyClassBase))
            {
                this.pMyMethodOverridden = OverriddenCacheStatus.NotOverridden;
                return false;
            }
            this.pMyMethodOverridden = OverriddenCacheStatus.Overridden;
            return true;
        }
        /// <summary>Our overridable method. Can be any kind of visibility.</summary>
        protected virtual int MyMethod(string parameter)
        {
            // Default implementation
            return 1980;
        }
        /// <summary>Demo function that calls our method and print some stuff.</summary>
        public void DemoMethod()
        {
            Console.WriteLine(this.GetType().Name + " result:" + this.MyMethod("x") + " overridden:" + this.IsMyMethodOverridden());
        }
    }
    public class ClassSecond :
        MyClassBase
    {
    }
    public class COverridden :
        MyClassBase
    {
        protected override int MyMethod(string parameter)
        {
            return 2011;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClassBase a = new MyClassBase();
            a.DemoMethod();
            a = new ClassSecond();
            a.DemoMethod();
            a = new COverridden();
            a.DemoMethod();
            Console.ReadLine();
        }
    }
