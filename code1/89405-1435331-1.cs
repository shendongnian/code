    // in MainPage:
    IList<IMainInterface> gadgets = new List<IMainInterface>
    {
    (IMainInterface)Activator.CreateInstance(Type.GetType("Gadgets.CalendarGadget")),
    (IMainInterface)Activator.CreateInstance(Type.GetType("Gadgets.TaskGadget")),
    };
