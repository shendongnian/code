    class WpfPage
    {
       public List OrderedListForTag1 { set { /* whatever GUI binding code you need to deal with the new list for tag 1 */ }
    
    
       public List OrderedListForTag2 { set { /* whatever GUI binding code you need to deal with the new list for tag 2*/ }
    
    }
    
    class WpfPresenter
    {
      WpfPage thePage;
      
      public void Tag1Selected()
      {
          //Calculate changes to 01, 02, 04 etcetce
          //If changed, update the page
          thePage.OrderedListForTag1 = //new list of objects
      }
    }
