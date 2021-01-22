    EventHandlerList listaEventos;
    private void btnDetach_Click(object sender, EventArgs e)
    {
        listaEventos = DetachEvents(comboBox1);
    }
    private void btnAttach_Click(object sender, EventArgs e)
    {
        AttachEvents(comboBox1, listaEventos);
    }
    public EventHandlerList DetachEvents(Component obj)
    {
        object objNew = obj.GetType().GetConstructor(new Type[] { }).Invoke(new object[] { });
        PropertyInfo propEvents = obj.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
        EventHandlerList eventHandlerList_obj = (EventHandlerList)propEvents.GetValue(obj, null);
        EventHandlerList eventHandlerList_objNew = (EventHandlerList)propEvents.GetValue(objNew, null);
        eventHandlerList_objNew.AddHandlers(eventHandlerList_obj);
        eventHandlerList_obj.Dispose();
        return eventHandlerList_objNew;
    }
    public void AttachEvents(Component obj, EventHandlerList eventos)
    {
        PropertyInfo propEvents = obj.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
        EventHandlerList eventHandlerList_obj = (EventHandlerList)propEvents.GetValue(obj, null);
        eventHandlerList_obj.AddHandlers(eventos);
    }
