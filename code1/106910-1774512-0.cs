    using namespace System;
    using namespace System::Collections::Generic;
    public ref class Candidate
    {
    public:  
        Candidate()
        {
        }
        property String^ Name
        {
            String^ get() { return this->name; }
            void set(String^ value) { this->name = value; }
        }
        property String^ LastName
        {
           String^ get() { return this->lastName; }
           void set(String^ value) { this->lastName = value; }
        }
    private:
        String^ name;
        String^ lastName;
    };
    public value class Results
    {
    public:
        Int32 Vote1;
        Int32 Vote2;
        Int32 Vote3;
        Candidate^ precinctCandidate;
    };
    int main(array<String^>^ args)
    {
        List<Results> votes = gcnew List<Results>();
        return 0;
    }
