    class Base {
    protected:
        virtual void Mumble(int arg) {}
    };
    
    class Derived : public Base {
    protected:
        // Override base class method
        void Mumble(long arg) {}
    };
