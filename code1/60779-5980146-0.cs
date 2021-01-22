    public interface class IFoo {
      void F(long bar);
    };
    public ref class Foo : public IFoo {
    public:
      virtual void F(long bar) { ... }
    };
