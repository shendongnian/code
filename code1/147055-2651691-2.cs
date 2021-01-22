    public abstract class MeasurementChannelAbstract
    {
        protected abstract void Method();
    }
    public class DeviceMeasurementChannel : MeasurementChannelAbstract
    {
        public void Method()
        {
            // Device side implementation here.
        }
    }
    public class HostMeasurementChannel : MeasurementChannelAbstract
    {
        public void Method()
        {
            // Host side implementation here.
        }
    }
