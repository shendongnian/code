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
