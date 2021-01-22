    void DoWork() {
        var commands = new Queue<ICommand>();
        commands.Enqueue(new MoreWorkCommand());
        while (!isStopping && !commands.IsEmpty)
        {
            commands.Deque().Perform(commands);
        }
    }
    public class MoreWorkCommand : ICommand {
        public void Perform(Queue<ICommand> commands) {
            commands.Enqueue(new DoMoreWorkCommand());
        }
    }
