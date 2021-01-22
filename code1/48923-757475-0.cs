    BaseClass{
      abstract void Add(ItemBaseClass item);  // not present!
      abstract ItemBaseClass CreateNewItem(); // not present!
    }
    
    SubClassA : BaseClass{
      override void Add(ItemA item) {...}
      override ItemA CreateNewItem() {...}
    }
    
    SubClassB: BaseClass{
      override void Add(ItemB item) {...}
      override ItemB CreateNewItem() {...}
    }
