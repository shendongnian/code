    EventCommandExecuter eventCommandExecuter = new EventCommandExecuter();
    BindingOperations.SetBinding(eventCommandExecuter, EventCommandExecuter.CommandProperty,
        new Binding { Path = new PropertyPath(bindingPath) });
    EventTrigger eventTrigger = new EventTrigger { EventName = "Drop" };
    eventTrigger.Actions.Add(eventCommandExecuter);
    Interaction.GetTriggers(itemsControl).Add(eventTrigger);
