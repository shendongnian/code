      class ClassA {
        public int Property { get; set; }
      }
      class ClassB {
        public ClassB() {
          ClassA a = new ClassA();
          ClassC c = new ClassC();
          c.setValue(ref a.Property);   // CS0206
        }
      }
      class ClassC {
        public void setValue(ref int value) {
          value = 42;
        }
      }
