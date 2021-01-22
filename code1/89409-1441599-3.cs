    // basic use of interfaces
    IMainInterface gadget = GadgetFactory.GetGadget("Gadgets.Calendar");
    gadget.SomeMethod();
    IOptionalInterface optional = gadget as IOptionalInterface;
    if( optional != null ) // if optional is null, the interface is not supported
        optional.SomeOptionalMethod();
