    namespace X
    {
        using System;
        /// <see cref="I1"/>  (or <see cref="X.I1"/> from outside X)
        /// <see cref="T:X.I1"/>
        interface I1
        {
            /// <see cref="I1.M1(int)"/>  (or <see cref="M1(int)"/> from inside I1)
            /// <see cref="M:X.I1.M1(System.Int32)"/>
            void M1(int p);
    
            /// <see cref="I1.M2{U}(U)"/>
            /// <see cref="M:X.I1.M2``1(``0)"/>
            void M2<U>(U p);
    
            /// <see cref="I1.M3(Action{string})"/>
            /// <see cref="M:X.I1.M3(System.Action{System.String})"/>
            void M3(Action<string> p);
        }
    
        /// <see cref="I2{T}"/>
        /// <see cref="T:X.I2`1"/>
        interface I2<T>
        {
            /// <see cref="I2{T}.M1(int)"/>
            /// <see cref="M:X.I2`1.M1(System.Int32)"/>
            void M1(int p);
    
            /// <see cref="I2{T}.M2(T)"/>
            /// <see cref="M:X.I2`1.M2(`0)"/>
            void M2(T p);
    
            /// <see cref="I2{T}.M3{U}(U)"/>
            /// <see cref="M:X.I2`1.M3``1(``0)"/>
            void M3<U>(U p);
        }
    }
