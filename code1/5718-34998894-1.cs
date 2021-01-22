    public class Person 
    {
      [DeepClone(DeepCloneBehavior.Shallow)]
      private Job _currentJob;      
      public string Name { get; set; }
      public Job CurrentJob 
      { 
        get{ return _currentJob; }
        set{ _currentJob = value; }
      }
      public Person Manager { get; set; }
    }
    public class Address 
    {      
      public Person PersonLivingHere { get; set; }
    }
    Address adr = new Address();
    adr.PersonLivingHere = new Person("John");
    adr.PersonLivingHere.BestFriend = new Person("James");
    adr.PersonLivingHere.CurrentJob = new Job("Programmer");
    
    Address adrClone = adr.Clone();
    //RESULT
    adr.PersonLivingHere == adrClone.PersonLivingHere //false
    adr.PersonLivingHere.Manager == adrClone.PersonLivingHere.Manager //false
    adr.PersonLivingHere.CurrentJob == adrClone.PersonLivingHere.CurrentJob //true
    adr.PersonLivingHere.CurrentJob.AnyProperty == adrClone.PersonLivingHere.CurrentJob.AnyProperty //true
