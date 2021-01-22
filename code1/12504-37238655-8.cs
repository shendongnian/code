    public class PlayerIdleState: Controller.StateBase
    {
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Console.WriteLine("PlayerIdleState.OnUpdate()");
        }
    }
