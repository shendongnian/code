    public interface ICommandStep
    {
        void Execute(CommandParameters cParams);
        string StepName { get; }
    }
    public abstract class CommandBase : ICommandStep
    {
        public void Execute(CommandParameters cParams)
        {
            PreExecute();
            ExecuteInternal(cParams);
            PostExecute();
        }
        protected virtual void PostExecute()
        {
        }
        protected virtual void ExecuteInternal(CommandParameters cParams)
        {
        }
        protected virtual void PreExecute()
        {
        }
        public abstract string StepName { get; }
    }
    public class Step1 : CommandBase
    {
        public override string StepName => "Initial Step";
        protected override void ExecuteInternal(object cParams)
        {
            // instructions
        }
    }
