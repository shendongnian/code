    class Parent
    {
      public Parent(Child child)
      {
        Child = child;
        Child.UpdateYourStatus += ComputeNewStateAndOutput;
      }
      Child Child {get; set;}
      private void ComputeNewStateAndOutput(sender, e) { ... }
      public void DisownChild()
      {
        //You are no longer my son (sigh, heard that one before)
        Child.UpdateYourStatus -= ComputeNewStateAndOutput;
      }
    }
    class Child
    {
      public event EventHandler UpdateYourStatus;
    }
    
