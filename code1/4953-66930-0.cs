    public __gc class MyClass_Net {
    public:
       MyClass_Net()
          :native_ptr_(new MyClass())
       {
       }
       ~MyClass_Net()
       {
          delete native_ptr_;
       }
    
    private:
       MyClass __nogc *native_ptr_;
    };
