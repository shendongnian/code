    public class MeasurementChannel
    {
        private MeasurementStrategyAbstract m_strategy;
        public MeasurementChannel(MeasurementStrategyAbstract strategy)
        {
            m_strategy = strategy;
        }
        protected void Method()
        {
            m_strategy.Measure();
        }
    }
    public abstract class MeasurementStrategyAbstract
    {
        protected abstract void Measure();
    }
    public class DeviceMeasurementStrategy : MeasurementStrategyAbstract
    {
        public void Measure()
        {
            // Device side implementation here.
        }
    }
    public class HostMeasurementStrategy : MeasurementStrategyAbstract
    {
        public void Measure()
        {
            // Host side implementation here.
        }
    }
