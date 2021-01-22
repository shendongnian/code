    generic<class T>
    public ref class B
    {
    public:
      void Test(){}
    };
    
    
    public ref class A : public B<System::Int32>
    {
    };
