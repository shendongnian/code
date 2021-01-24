    using System;
    namespace ConsoleApplication6
    {
        /// <summary>
        /// This is the component in Decorator Pattern
        /// </summary>
        public interface ICommandStep
        {
            void Execute(String cParams);
            string StepName { get; }
        }
        /// <summary>
        /// This is the concrete component in Decorator Pattern
        /// </summary>
        public class ConcreteStep1 : ICommandStep
        {
            public string StepName
            {
                get
                {
                    return "1";
                }
            }
            public void Execute(string cParams)
            {
                Console.WriteLine($"STEP {StepName}: EXECUTE");
            }
        }
        /// <summary>
        /// This is the decorator in Decorator Pattern
        /// </summary>
        public abstract class StepDecorator : ICommandStep
        {
            protected ICommandStep _commandStep;
            public abstract string StepName
            {
                get;
            }
            public StepDecorator(ICommandStep commandStep)
            {
                this._commandStep = commandStep;
            }
            public abstract void Execute(string cParams);
        }
        /// <summary>
        /// This is the concrete decorator in Decorator Pattern
        /// </summary>
        public class ConcreteStepDecorator : StepDecorator
        {
            public ConcreteStepDecorator(ICommandStep commandStep) : base(commandStep) { }
            public override string StepName
            {
                get
                {
                    return _commandStep.StepName;
                }
            }
            public override void Execute(string cParams)
            {
                // You can do whatever you want before / after execution of command
                Console.WriteLine($"STEP {_commandStep.StepName}: PRE EXECUTE");
                _commandStep.Execute(cParams);
                Console.WriteLine($"STEP {_commandStep.StepName}: POST EXECUTE");
            }
        }
        /// <summary>
        /// This is a Simple Factory. You encapsulate here creation of ICommandStep, so that it will always be decorated
        /// </summary>
        public class SimpleStepFactory
        {
            public ICommandStep createStep()
            {
                return new ConcreteStepDecorator(new ConcreteStep1());
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var step = new SimpleStepFactory().createStep();
                step.Execute("params");
                Console.ReadLine();
            }
        }
    }
