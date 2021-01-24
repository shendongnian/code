    class MoveNextCommand : ICommand 
    {
        ...... <Your implementation>
    }
    public class TestViewModel 
    {
        ...
        private ICommand _moveNextCmd;
        public ICommand MoveNextCmd 
        {
            get { return _moveNextCmd ?? (_moveNextCmd = new MoveNextCommand()); }
        }
        ...
    }
