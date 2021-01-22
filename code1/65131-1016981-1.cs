    class Pair { 
      A a; B b; 
      Pair(A a, B b) { this.a = a; this.b = b; } 
      // Also override Equals(), HashCode()
    }
    class AssociationTalbe {
      Set<Pair> pairs = ...;
      void add(A a, B b) { pairs.add(new Pair(a, b)); }
      void remove(A a, B b) { pairs.remove(new Pair(a, b)); }
    }
    class A {
      AssociationTable table;
      
      public A(AssociationTable t) { table = t; }
      void add(B b) { table.add(this, b); }
      void remove(B b) { table.remove(this, b); }
    }
