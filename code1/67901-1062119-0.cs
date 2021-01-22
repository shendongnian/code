    class Params {
    public:
       virtual void Manipulate() { //basic impl here }
    }
    class DerivedParams1 : public Params {
    public:
       override void Manipulate() {
          base.Manipulate();
          // other statements here
       }
    };
    // more derived classes can do the same
    void ManipulateAll( Params[] params )
    {
        for( int i = 0; i < params.Length; i++ ) {
           params[i].Manipulate();
        }
     }
    
