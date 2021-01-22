    public delegate void OnlyRuller(string s1, string s2);
    public delegate void RullerCoronation(OnlyRuller d);
    class Foo {
      private Foo();
      public Foo(RullerCoronation followMyOrders) {
         followMyOrders(SetMe);
      }
      private SetMe(string whatToSet, string whitWhatValue) {
         //lot of unclear but private code
      }
    }
