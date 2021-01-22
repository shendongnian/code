    class ControllerTest: Controller
    {
        public ControllerTest()
        {
            IState testObj = new PlayerIdleState();
            testObj.Update();
        }
    }
