    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication86
    {
        class Program
        {
            static void Main(string[] args)
            {
                int circuitConnectId = 123;
                var devices = (from device in UnitOfWork.Device
                               join deviceCircuit in UnitOfWork.DeviceCircuit on device.Id equals deviceCircuit.Id
                               where
                                    deviceCircuit.CircuitConnectId == circuitConnectId
                               select new { device = device, deviceCircuit = deviceCircuit })
                               .Select(x => new
                               {
                                   meters = x.device.Meters.Select(y => new { deviceName = x.device.DeviceName, deviceId = x.device.Id, meterId = y.Id, meterName = y.MeterName, circuitId = x.deviceCircuit.Id, circuitDisplayName = x.deviceCircuit.DisplayName }),
                               }).ToList();
                               
                       
             }
        }
        public class UnitOfWork
        {
            public static List<Device> Device { get; set; }
            public static List<DeviceHierarchyDataItem> DeviceCircuit { get; set; }
        }
        public class DeviceHierarchyDataItem
        {
            public int Id { get; set; } //<-- the 'Id' of the Device or Meter
            public int? ChildOf { get; set; }  //<-- the 'Id' of the PARENT Device or NULL
            public int CircuitConnectId { get; set; }
            public string DisplayName { get; set; } //<-- the 'Name' of the Device or Meter
        }
        public class Device
        {
            public int Id { get; set; }
            public string DeviceName { get; set; }
            public List<Meter> Meters { get; set; }
        }
        public class Meter
        {
            public int Id { get; set; }
            public string MeterName { get; set; }
        }
    }
