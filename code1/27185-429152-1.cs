       class IThing
       { 
            public:
              virtual void DoThing() = 0;
       }; 
    
       class NullThing : public IThing
       { 
            public:
              virtual void DoThing() { /*no-op*/}
       }; 
    
       class RealThing : public IThing
       { 
            public:
              virtual void DoThing() { /*does something real*/}
       }; 
    
       int main()
       {
             NullThing theNullInstance; /* often a singleton or static*/
             IThing* thingy = &theNullInstance; /*the null value*/
             
             // Do stuff that may or may not set  thingy to a RealThing
             
             thingy->DoThing(); // If is NullThing, does nothing, otherwise does something
             // Can still check for null 
             // If NullThing is a singleton
             if (thingy == &theNullInstance)
             {
                  printf("Uhoh, Null thingy!\n"); 
             }
       }
     
