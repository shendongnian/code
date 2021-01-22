    public class PlayerIdleState: Controller.StateBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            Console.WriteLine("PlayerIdleState.OnEnter()");
        }
    }
