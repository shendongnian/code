      static void Foo<T>( T? a ) where T : struct
      {
         // nullable stuff here
      }
      static void Foo<T>( T a )
      {
         if( a is ValueType )
         {
            // ValueType stuff here
         }
         else
         {
            // class stuff
         }
      }
