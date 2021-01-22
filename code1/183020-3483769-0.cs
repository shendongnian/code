    public void UpdateUI() {
        if (this.InvokeRequired) {
            this.Invoke(new MethodInvoker(UpdateUI));
        } else {
            // Changes to UI are made here.
        }
    }
