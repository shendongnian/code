    class SuperDuperClassWithLotsAndLotsOfProperties {
      object Clone() {
        return new SuperDuperClassWithLotsAndLotsOfProperties {
          Property1 = Property1,
          Property2 = Property2,
        }
    
      public string Property1 {get;set;}
      public string Property2 {get;set;}
      }
    }
