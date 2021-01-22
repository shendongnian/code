    private static void main(string[] args) {
         Container container = new Container();
         // Configure the container - by hand or via file
         IProgramLogic logic = container.Resolve<IProgramLogic>();
         logic.Run();
    }
