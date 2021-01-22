    // v1
    public abstract class A
    {
        void DoSomething()
        {
            ...
            if (someCondition)
            {
                throw new SomeException();
            }
        }
    }
