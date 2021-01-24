    public class DeviceStateController : Controller
    {
        IIndex<DeviceState, IDeviceState> _states;
        public DeviceStateController(IIndex<DeviceState, IDeviceState> states)
        {
            _states = states;
        }
        // GET api/values
        [HttpGet]
        public IActionResult GetDeviceState(DeviceState deviceEnum)
        {
            //Must Return Different Types
            return Ok(_states[deviceEnum].GetDeviceStateInformation());
        }
    }
    [TestFixture]
    public class DeviceStateControllerTests
    {
        [Test]
        public void GetDeviceStateTest()
        {
            // Arrange
            var builder = new ContainerBuilder();
            builder.RegisterType<OnlineState>().Keyed<IDeviceState>(DeviceState.Online);
            builder.RegisterType<OfflineState>().Keyed<IDeviceState>(DeviceState.Offline);
            builder.RegisterType<DeviceStateController>();
            var container = builder.Build();
            var controller = container.Resolve<DeviceStateController>();
            // Act
            var stringResult = (OkObjectResult)controller.GetDeviceState(DeviceState.Online);
            var intResult = (OkObjectResult)controller.GetDeviceState(DeviceState.Offline);
            //Assert
            Assert.AreEqual(stringResult.Value, "Online");
            Assert.AreEqual(intResult.Value, 404);
        }
    }
    public interface IDeviceState
    {
        object GetDeviceStateInformation();
    }
    public interface IDeviceState<T> : IDeviceState
    {
        new T GetDeviceStateInformation();
    }
    public abstract class DeviceState<T>: IDeviceState<T>
    {
        public abstract T GetDeviceStateInformation();
        object IDeviceState.GetDeviceStateInformation()
        {
            return GetDeviceStateInformation();
        }
    }
    public class OnlineState : DeviceState<string>
    {
        public override string GetDeviceStateInformation()
        {
            return "Online";
        }
    }
    public class OfflineState : DeviceState<int>
    {
        public override int GetDeviceStateInformation()
        {
            return 404;
        }
    }
    public enum DeviceState
    {
        Online = 1,
        Offline = 2
    }
