    internal enum PropertyOption { Prop1, Prop2 }
    
    internal class Bar {
      PropertyOptiion prop;
      public Bar(PropertyOption prop) {
        this.prop = prop;
      }
      public override OnFoo() {
        switch (prop) {
          case PropertyOption.Prop1:
            this.prop1 = !this.prop1;
            break;
          case PropertyOption.Prop2:
            this.prop2 = !this.prop2;
            break;
        }
      }
    }
