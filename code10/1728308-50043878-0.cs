    public class DeviceRepository<T>: InjectionMember, IDeviceRepository<T>
    where T : TableEntity, new()
    {
        ...
    }
