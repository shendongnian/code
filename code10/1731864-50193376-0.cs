    abstract class Action
        {
            public void Perform(SelectList list)
            {
              Console.WriteLine("CheckText");
            }
        }
    class CheckBoxAction1:Action
    {
        public void Perform(SelectList list)
        {
          Console.WriteLine("CheckText1");
        }
    }
    class CheckBoxAction2:Action
    {
        public void Perform(SelectList list)
        {
          Console.WriteLine("CheckText2");
        }
    }
    class ComposedActions{
        private Action _action;
        public ComposedActions(Action action)
        { 
          _action=action;
        }
        public void Perform(SelectList list)
        {
          _action.Perform(list);
        }
     }
    ComposedActions action1= new ComposedActions(new CheckBoxAction1());
    ComposedActions action2= new ComposedActions(new CheckBoxAction2());
    SelectList list = new SelectList();
    action1.Perform(list);
    //CheckText1
    action2.Perform(list);
    //CheckText2
