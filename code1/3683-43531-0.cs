    class B : A
    {
      protected sealed override void SpecialRender()
      {
        // do stuff
      }
    }
    class C : B
      protected override void SpecialRender()
      {
        // not valid
      }
    }
