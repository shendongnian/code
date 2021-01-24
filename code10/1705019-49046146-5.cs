    using System;
    
    public interface IM
    {
        void SendM(IRM target, string message);
    }
    
    public interface IN
    {
        void SendN(IRN target, string message);
    }
    
    public interface IRM
    {
        string ReceiveM(string message);
    }
    
    public interface IRN
    {
        string ReceiveN(string message);
    }
    
    public class WrapSender : IM
    {
        class NonGenericSender
        {
            public string Message(string message)
            {
                return message;
            }
        }
    
        public void Run(IRM target)
        {
            var s = new NonGenericSender();
            SendM(target, s.Message("M"));
        }
    
        public void SendM(IRM target, string message) => target.ReceiveM(message);
    }
    
    public class WrapX : IN
    {
        class X
        {
            public string Message(string message) => message;
        }
    
        public void Run(IRN target)
        {
            var s = new X();
            SendN(target,s.Message("N"));
        }
    
        public void SendN(IRN target, string message) => target.ReceiveN(message);
    }
    
    public class Receiver : IRN, IRM
    {
        public string ReceiveM(string message)
        {
            throw new NotImplementedException();
        }
    
        public string ReceiveN(string message)
        {
            throw new NotImplementedException();
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            var r = new Receiver();
            var s = new WrapSender();
            s.Run(r); // gets message from wrapped class
            s.SendM(r, "message via M");
            var x = new WrapX();
            x.Run(r); // gets message from wrapped class
            x.SendN(r, "message via N");
            s.SendN(r,"does not compile nor in intellisense");
        }
    } 
