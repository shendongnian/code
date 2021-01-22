    private void delegateHandler(string senderName, object sender, CustomEventType evt)
    {
        FieldInfo field = this.GetType().GetField(senderName, BindingFlags.NonPublic | BindingFlags.Instance);
        if(field != null && field.Name == senderName)
        {
            CatClass cat = (CatClass)field.GetValue(this);
            cat.DoWork();
        }
    }
