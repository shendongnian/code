    class DerivedA : public BaseA
    {
    public:
        void foo() final // better than override:
                         // prevents breaking the pattern again
        { fooA() };
    protected:
        virtual void fooA() = 0;
    };
    class DerivedB : public BaseB
    {
    public:
        int foo() final { return fooB() };
    protected:
        virtual int fooB() = 0;
    };
