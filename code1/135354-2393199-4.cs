    IPerson
    {
       string Name {get; set;}
       string LastName {get; set;}
       // whatever else - such as sizeOfShoe, dob, etc
    }
    IHaveParents
    {
       // might wanna limit this to a fixed size
       List<IPerson> Parents {get; set;}
    }
    IHaveChildren
    {
       List<IPerson> Children {get; set;}
    }
    IHaveSpouse
    {
       IPerson Spouse {get; set;}
    }
    public class DudeWithParentsAndChildren : IPerson, IHaveParents, IHaveChildren, IHaveSpouse
    {       
       public void AskMoneyToParents(){throw new Exception("Implement me!");}
       public void SlapChildren(){}
       private void CheatOnSpouse(){}
       // some other stuff that such a dude can do i.e. GoBowling
    }
