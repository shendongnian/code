    public class DeviceRepository
    {
        private DeviceManagerEntities context;
        public DeviceRepository(DeviceManagerEntities context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            this.context = context;
        }
        public int GetDeviceCount(Guid managementGroupID)
        {
            return GetDeviceCount(new Guid[] { managementGroupID });
        }
        public int GetDeviceCount(IEnumerable<Guid> managementGroupIDs)
        {
            int deviceCount = context.Devices
                .Where(d => managementGroupIDs.Contains(
                    d.ManagementGroups.ManagementGroupID))
                .Count();
            var childGroupIDs = context.ManagementGroups
                .Where(g => managementGroupIDs.Contains(g.ParentId))
                .Select(g => g.ManagementGroupID);
            deviceCount += GetDeviceCount(childGroupIDs);
            return deviceCount;
        }
    }
