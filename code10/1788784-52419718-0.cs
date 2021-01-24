    public interface IOperable
    {
        void Operate();
    }
    public class Operable : IOperable
    {
       ...
    }
    public class OperableOther : IOperable
    {
       ...
    }
    ...
    IOperable ioperable = new Operable();
    ioperable.Operate(); // at this time will invoke Operable.Operate();
    ioperable = new OperableOther();
    ioperable.Operate(); // at this time will OperableOther.Operate();
