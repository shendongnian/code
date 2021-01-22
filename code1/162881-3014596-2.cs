    // Either in the MoreWork constructor
    public MoreWork(IController controller) {
        this.controller = controller;
    }
    // Or in DoMoreWork, depending on your preferences
    public void DoMoreWork(IController controller) {
        do {
            // More work here
        } while (!controller.IsStopping);
    }
