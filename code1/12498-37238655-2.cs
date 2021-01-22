    public class Controller
	{
		protected interface IState
		{
			void Update();
		}
		public class StateBase : IState
		{
            void IState.Update() { OnUpdate(); }
            protected virtual void OnUpdate()
            {
				Console.WriteLine("StateBase.OnEnter()");
            }
		}
		public Controller()
		{
			IState obj = new PlayerIdleState();
			obj.Update();
		}
	}
