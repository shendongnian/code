    class MyClass
    {
      private List<Panel> _panels = new List<Panel>();
      void MethodWhichCreatesThePanels()
      {
        //..
        foreach (string[] Persons in alItems)
        {
          Panel pPanelContainer = new Panel();
          _panels.Add(pPanelContainer);
          ...
        }  
      }
