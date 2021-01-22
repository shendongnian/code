    public class RunStateController
    {
       public RunState CurrentState { get; private set; }
       
       public void Start()
       {
           // reset everything
           Run();
       }
       public void Run() 
       {
           State = new RunningState();
           // do the running code here
       }
       public void Pause()
       {
          State = new PausedState();
          // do the pause logic here
       }
    }
    public abstract class RunState
    {
       public abstract void Change(RunStateContext context);
    }
    public class StartState : RunState
    {
       public override void Change(RunStateContext context)
       {
          context.Run();
       }
    }
    public class RunningState : RunState
    {
       public override void Change(RunStateContext context)
       {
          context.Run();
       }
    }
    public class Form....
    {
       private void cmdStart_Click(object sender, RoutedEventArgs e)
       {
          m_controller.CurrentState.Change();
       }
       
    }
