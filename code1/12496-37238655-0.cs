	public class Controller
	{
		private interface IState
		{
			void Update();
		}
		public class StateBase : IState
		{
			void IState.Update() {  }
		}
		public Controller()
		{
            //it's only way call Update is to cast obj to IState
			IState obj = new StateBase();
			obj.Update();
		}
	}
