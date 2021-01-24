    [Test]
    public void DeviceStateResolveTest()
    {
        // Arrange
        var builder = new ContainerBuilder();
        builder.RegisterType<OnlineState>().AsImplementedInterfaces();
        builder.RegisterType<OfflineState>().AsImplementedInterfaces();
        var container = builder.Build();
        // Act
        var state1 = container.Resolve<IDeviceState<string>>();
        var state2 = container.Resolve<IDeviceState<int>>();
        // Assert
        Assert.AreEqual(string.Empty, state1.GetDeviceStateInformation());
        Assert.AreEqual(5, state2.GetDeviceStateInformation());
    }
    public interface IDeviceState<T>
    {
        T GetDeviceStateInformation();
    }
    public class OnlineState : IDeviceState<string>
    {
        public string GetDeviceStateInformation()
        {
            return String.Empty;
        }
    }
    public class OfflineState : IDeviceState<int>
    {
        public int GetDeviceStateInformation()
        {
            return 5;
        }
    }
