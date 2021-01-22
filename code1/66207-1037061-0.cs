    public interface IServices
    {
        DataManager Data { get; set; }
        LogManager Log { get; set; }
        SomeOtherManager SomeOther { get; set; }
    }
    public class MrPlugin
    {
        public void Init(IServices services)
        {
            // Do stuff with services
        }
    }
