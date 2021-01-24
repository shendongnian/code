    public interface IDataInput { }
    public interface IDataStep1 { }
    public interface IDataStep2 { }
    public interface IDataStep3 { }
    public interface IDataStepN { }
    public interface IDataOutput { }
    public interface IStepProcessor<TInput, TOutput>
    {
        TOutput Process(TInput input);
    }
    public delegate TOutput Conveyor<TInput, TOutput>(TInput input);
    public class Factory
    {
        private readonly IStepProcessor<IDataInput, IDataStep1> m_Step1;
        private readonly IStepProcessor<IDataStep1, IDataStep2> m_Task2;
        private readonly IStepProcessor<IDataStep2, IDataStep3> m_Task3;
        private readonly IStepProcessor<IDataStep3, IDataStepN> m_TaskN;
        private readonly IStepProcessor<IDataStepN, IDataOutput> m_FinalTask;
        public Factory(
            IStepProcessor<IDataInput, IDataStep1> task1,
            IStepProcessor<IDataStep1, IDataStep2> task2,
            IStepProcessor<IDataStep2, IDataStep3> task3,
            IStepProcessor<IDataStep3, IDataStepN> taskN,
            IStepProcessor<IDataStepN, IDataOutput> finalTask
            )
        {
            m_Step1 = task1;
            m_Task2 = task2;
            m_Task3 = task3;
            m_TaskN = taskN;
            m_FinalTask = finalTask;
        }
        public Conveyor<IDataInput, IDataOutput> BuildConveyor()
        {
            return (input) =>
            {
                return m_FinalTask.Process(
                    m_TaskN.Process(
                        m_Task3.Process(
                            m_Task2.Process(
                                m_Step1.Process(input)))));
            };
        }
    }
    public class Client
    {
        private readonly Conveyor<IDataInput, IDataOutput> m_Conveyor;
        public Client(Conveyor<IDataInput, IDataOutput> conveyor)
        {
            m_Conveyor = conveyor;
        }
        public void DealWithInputAfterTransformingIt(IDataInput input)
        {
            var output = m_Conveyor(input);
            Console.Write($"Mind your business here {typeof(IDataOutput).IsAssignableFrom(output.GetType())}");
        }
    }
    public class Program {
        
        public void StartingPoint(IServiceProvider serviceProvider)
        {
            ISomeDIContainer container = CreateDI();
            container.Register<IStepProcessor<IDataInput, IDataStep1>, Step1Imp>();
            container.Register<IStepProcessor<IDataStep1, IDataStep2>, Step2Imp>();
            container.Register<IStepProcessor<IDataStep2, IDataStep3>, Step3Imp>();
            container.Register<IStepProcessor<IDataStep3, IDataStepN>, StepNImp>();
            container.Register<IStepProcessor<IDataStepN, IDataOutput>, StepOImp>();
            container.Register<Factory>();
            Factory factory = container.Resolve<Factory>();
            var conveyor = factory.BuildConveyor();
            var client = new Client(conveyor);
        }
    }
