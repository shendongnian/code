    public abstract class Device
    {
        public abstract string Description();
    }
    public class Computer : Device
    {
        public Computer() { }
        public override string Description()
        {
            return "Computer";
        }
    }
    public class Monitor : Device
    {
        Device device;
        public Monitor(Device c)
        {            this.device = c;
        }
        public override string Description()
        {
            return device.Description() + " and a Monitor";
        }
    }
    public class Disk : Device
    {
        Device device;
        public Disk(Device c)
        {
            this.device = c;
        }
        public override string Description()
        {
            return device.Description() + " and a Disk";
        }
    }
