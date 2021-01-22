    public class Child : IPerson, IHaveParents
    {       
       public void AskMoneyToParents(){throw new Exception("Implement me!");}
    }
    public class Parent : IPerson, IHaveChildren, IHaveSpouse
    {       
       public void SlapChildren(){}
       private void CheatOnSpouse(){}
       // some other stuff that such a dude can do i.e. GoBowling
    }
