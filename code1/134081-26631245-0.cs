    private void DoGUISwitch() {
        if (object1.InvokeRequired) {
            object1.Invoke(new MethodInvoker(() => { DoGUISwitch(); }));
        } else {
            object1.Visible = true;
            object2.Visible = false;
        }
    }
