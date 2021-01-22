    abstract class FuzzyContainer : IContainer{
      protected virtual string GetName(){
       return "Fuzzy Container";
      }
    }
    
    class SpecialContainer: FuzzyContainer{
      override string GetName(){
       return base.GetName() + " Special Container";
      }
    }
