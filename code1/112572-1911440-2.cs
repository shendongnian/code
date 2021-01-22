    public class ActionTest
    {
        private readonly Dictionary<string, Action> _actions = new Dictionary<string, Action>();
        public ActionTest()
        {
            _actions.Add(ReflectionTestMethods.MethodA.ToString(), new Action(MethodA));
            _actions.Add(ReflectionTestMethods.MethodB.ToString(), new Action(MethodB));
            _actions.Add(ReflectionTestMethods.MethodC.ToString(), new Action(MethodC));
        }
        public void Execute(ReflectionTestMethods method)
        {
            if (!_actions.ContainsKey(method.ToString())) 
                throw new NotImplementedException(method.ToString());
            _actions[method.ToString()]();
        }
        private void MethodA()
        {
            Debug.Print("MethodA");
        }
        private void MethodB()
        {
            Debug.Print("MethodB");
        }
        private void MethodC()
        {
            Debug.Print("MethodC");
        }
    }
