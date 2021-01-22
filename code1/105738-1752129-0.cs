    public interface ICommandContext 
    {
    void Cut();
    void Copy();
    void Past();
    void AutoFormat(); 
    }
    public SourceView : ICommandContext
    {
        public void Cut()
        {
            // Do stuff here...
        }
    }
    
    public class CopyCommand : Command
    {
        public override Execute(ICommandContext context)
        {
            context.Copy();
        }
    }
