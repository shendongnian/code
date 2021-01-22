    using namespace System;
    // CLI/C++ "managed" interface 
    interface class IDog
    {
        void Bark();
    };
    #pragma managed(push off)
    // Native C++
    class Pet
    {
    public:
       Pet() {}
       ~Pet() {}
       const char* GetNativeTypeName()
       {
           return typeid(Pet).name();
       }
    };
    #pragma managed(pop)
    // CLI/C++ "managed" class
    ref class Dog : IDog
    {
    private:
        Pet* _nativePet;
    public:
        Dog()
          : _nativePet(new Pet())
        {}
        ~Dog()
        {
            delete _nativePet; 
            _nativePet = 0;
        }
        void Bark()
        {
            // Managed code talking to native code, cats & dogs living together, oh my!
            Console::WriteLine("Bow wow wow!");
            Console::WriteLine(new System::String(_nativePet->GetNativeTypeName()));
        }
    };
    void _tmain()
    {
        Dog^ d = gcnew Dog();
        d->Bark();
    }
