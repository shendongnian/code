      using System;
    
        //  Singleton Pattern      Judith Bishop Nov 2007
        //  The public property protects the private constructor
          
        public class Singleton {
          // Private constructor 
          Singleton () { }
          
          // Nested class for lazy instantiation
          class SingletonCreator {
            static SingletonCreator () {}
            // Private object instantiated with private constructor
            internal static readonly 
            Singleton uniqueInstance = new Singleton();
          }
    
          // Public static property to get the object
          public static Singleton UniqueInstance {
            get {return SingletonCreator.uniqueInstance;}
          }
        }
   
    
