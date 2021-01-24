    public interface IMyInterface
    {
        void DoSomething();
    }
    public class WinClass: IMyInterface
    {
        public void DoSomething()
        {
            //Implementation of DoSomething for Windows
        }
    }
    public class NixClass : IMyInterface
    {
        public void DoSomething()
        {
            //Implementation of DoSomething for *nix
        }
    }
