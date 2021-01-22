        Type t = typeof(Button);
        object[] p = new object[1];
        p[0] = EventArgs.Empty;
        MethodInfo m = t.GetMethod("OnClick", BindingFlags.NonPublic | BindingFlags.Instance);
        m.Invoke(btnYourButton, p);
