    public interface ICommandStep
    {
        void Execute(CommandParameters cParams);
        string StepName { get; }
    }
    public interface ICommandStep2 : ICommandStep
    {
        void PreExecute()
        void PostExecute()
    }
    public static class Extensions
    {
        public static void Execute2(this ICommandStep step, CommandParameters cParams)
        {
            if( step is ICommandStep2 step2 )
            {
                step2.PreExecute();
                step2.Execute( cParams );
                step2.PostExecute();
            }
            else
            {
                step2.Execute( cParams );
            }
        }
    }
