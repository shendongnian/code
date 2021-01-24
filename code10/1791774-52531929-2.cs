    public class DeviceStateController : Controller
    {
        IIndex<DeviceState, IDeviceState> _states;
        public DeviceStateController(IIndex<DeviceState, IDeviceState> states)
        {
            _states = states;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetDeviceState(DeviceState deviceEnum)
        {
            //Must Return Different Types
            var result = await _states[deviceEnum].GetDeviceStateInformation();
            return Ok(result);
        }
    }
    [TestFixture]
    public class DeviceStateControllerTests
    {
        [Test]
        public async Task GetDeviceStateTest()
        {
            // Arrange
            var builder = new ContainerBuilder();
            builder.RegisterType<OnlineState>().Keyed<IDeviceState>(DeviceState.Online);
            builder.RegisterType<OfflineState>().Keyed<IDeviceState>(DeviceState.Offline);
            builder.RegisterType<DeviceStateController>();
            var container = builder.Build();
            var controller = container.Resolve<DeviceStateController>();
            // Act
            var stringResult = (OkObjectResult)await  controller.GetDeviceState(DeviceState.Online);
            var intResult = (OkObjectResult)await controller.GetDeviceState(DeviceState.Offline);
            //Assert
            Assert.AreEqual(stringResult.Value, "Online");
            Assert.AreEqual(intResult.Value, 404);
        }
    }
    public interface IDeviceState
    {
        Task<object> GetDeviceStateInformation();
    }
    public interface IDeviceState<T> : IDeviceState
    {
        new Task<T> GetDeviceStateInformation();
    }
    public abstract class DeviceState<T> : IDeviceState<T>
    {
        public abstract Task<T> GetDeviceStateInformation();
        async Task<object> IDeviceState.GetDeviceStateInformation()
        {
            return await GetDeviceStateInformation();
        }
    }
    public class OnlineState : DeviceState<string>
    {
        public override async Task<string> GetDeviceStateInformation()
        {
            return await Task.FromResult("Online");
        }
    }
    public class OfflineState : DeviceState<int>
    {
        public override async Task<int> GetDeviceStateInformation()
        {
            return await Task.FromResult(404);
        }
    }
    public enum DeviceState
    {
        Online = 1,
        Offline = 2
    }
