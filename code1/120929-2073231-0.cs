    interface I1 { void Draw(); }
    interface I2 { void Draw(); }
    class A : I1, I2
    {
        // this is just a method in A
        public void Minstance() { Console.WriteLine("A::MInstance"); }
        // method in A, also implements I1.Draw. May be overridden in
        // derived types.
        public virtual void Draw() { Console.WriteLine("A::Draw"); }
        // implements I2.Draw, accessible on object a of type A via ((I2)a).Draw()
        void I2.Draw() { Console.WriteLine("A::I2.Draw"); }
    }
    class B : A, I1, I2
    {
        // new method in B, does not override A.Draw, so A.Draw is only
        // callable on an object b of type B via ((A)b).Draw(). Types
        // derived from B may override this method, but can't override
        // A.Draw because it's hidden. Also implements I2.Draw (see notes).
        public new virtual void Draw() { Console.WriteLine("B::Draw"); }
        // implements I1.Draw, accessible on object b of type B via ((I1)b).Draw()
        void I1.Draw() { Console.WriteLine("B::I2.Draw"); }
    }
