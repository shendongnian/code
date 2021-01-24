    public abstract class AbstractMaker<T> where T:IMyDto
    {
        public abstract void DoSomething(T myInterface);
    }
    public class ConcreteMakerTwo : AbstractMaker<DtoTwo>
    {
        public override void DoSomething(DtoTwo myInterface)
        {
            // now you are certain that myInterface is a DtoTwo
        }
    }
