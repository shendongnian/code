        /// <summary>
        /// Gets information about devices in the device class including power state.
        /// </summary>
        /// <param name="classGuid">The GUID of the class in which to get information about devices from.</param>
        /// <returns></returns>
        public static List<DeviceInfo> GetInfoWithSetupDi(Guid classGuid) {
            List<DeviceInfo> deviceInfos = new List<DeviceInfo>();
            IntPtr deviceInfoSet = SetupDiGetClassDevsA(ref classGuid, null, IntPtr.Zero, 0x00000002 | 0x00000010);           
            uint index = 0;
            int error = 0;
            while (error == 0) {
                DeviceInfo curDevice = new DeviceInfo {
                    //Initializing SP_DEVINFO_DATA to be passed to SetupDiEnumDeviceInfo.
                    deviceInfoData = new SP_DEVINFO_DATA {
                        cbSize = 28
                    }
                };
                //Retrieves the information about the specified device.
                bool success = SetupDiEnumDeviceInfo(deviceInfoSet, index, ref curDevice.deviceInfoData);
                index++;
                error = Marshal.GetLastWin32Error();
                if (error == 259)
                    { break; }
                if (!success)
                    { throw new Exception("Native method call error: " + error.ToString()); }
                //Only add device after it was at least successfully retrieved.
                deviceInfos.Add(curDevice);
                //Retrieving individual information.
                RegistryData localGetData(uint property) => GetData(deviceInfoSet, curDevice.deviceInfoData, property);
                curDevice.hardwareId = (string[]) localGetData(SPDRP_HARDWAREID).parsed;
                try {
                    curDevice.description = (string)localGetData(SPDRP_DEVICEDESC).parsed;
                } catch {
                    curDevice.description = "Description not set.";
                }               
                curDevice.cmPowerData = MarshallingUtils.FromBytes<CM_POWER_DATA>(
                    localGetData(SPDRP_DEVICE_POWER_DATA).data
                );
            }
            return deviceInfos;           
        }
        /// <summary>
        /// Gets the required size in bytes for the given property.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to the set of devices.</param>
        /// <param name="property">The property for which the get the required size.</param>
        private static uint GetRequiredSize(IntPtr deviceInfoSet, uint Property) {
            SP_DEVINFO_DATA deviceInfoData = new SP_DEVINFO_DATA {
                cbSize = 28
            };
            ThrowErrorIfNotSuccessful(SetupDiEnumDeviceInfo(deviceInfoSet, 0, ref deviceInfoData));
            return GetRequiredSize(deviceInfoSet, Property, deviceInfoData);
        }
        /// <summary>
        /// Gets the required size in bytes for the given property.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to the set of devices.</param>
        /// <param name="property">The property for which the get the required size.</param>
        /// <param name="deviceInfoData">Info of a device.</param>
        /// <returns></returns>
        private static uint GetRequiredSize(IntPtr deviceInfoSet, uint property, SP_DEVINFO_DATA deviceInfoData) {
            ThrowErrorIfNotSuccessful(
                SetupDiGetDeviceRegistryPropertyA(
                    deviceInfoSet,
                    ref deviceInfoData,
                    property,
                    out RegistryDataType type,
                    new byte[1000],
                    1000,
                    out uint size)
                );
            return size;
        }
        /// <summary>
        /// Gets the property using SetupDi of the device on the given index in the given device class.
        /// </summary>
        /// <param name="classGuid">The GUID of the device class.</param>
        /// <param name="index">The index of the device.</param>
        /// <param name="property">The property to retrieve.</param>
        /// <returns></returns>
        public static RegistryData GetData(Guid classGuid, uint index, uint property) {
            IntPtr deviceInfoSet = SetupDiGetClassDevsA(ref classGuid, null, IntPtr.Zero, 0x00000002 | 0x00000010);
            SP_DEVINFO_DATA deviceInfoData = new SP_DEVINFO_DATA {
                cbSize = 28
            };
            ThrowErrorIfNotSuccessful(SetupDiEnumDeviceInfo(deviceInfoSet, index, ref deviceInfoData));
            return GetData(deviceInfoSet, deviceInfoData, property);
        }
        /// <summary>
        /// Gets the specified property using SetupDi of the device described in deviceInfoData in the given device info set.
        /// The size is retrieved automatically.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to the device info set.</param>
        /// <param name="deviceInfoData">Description of the device.</param>
        /// <param name="property">The property to retrieve.</param>
        /// <returns></returns>
        public static RegistryData GetData(IntPtr deviceInfoSet, SP_DEVINFO_DATA deviceInfoData, uint property) {
            uint size = GetRequiredSize(deviceInfoSet, property, deviceInfoData);
            return GetData(deviceInfoSet, deviceInfoData, property, size);
        }
        /// <summary>
        /// Gets the specified property using SetupDi of the device described in deviceInfoData in the given device info set.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to the device info set.</param>
        /// <param name="deviceInfoData">Description of the device.</param>
        /// <param name="property">The property to retrieve.</param>
        /// <returns></returns>
        public static RegistryData GetData(IntPtr deviceInfoSet, SP_DEVINFO_DATA deviceInfoData, uint property, uint size) {
            byte[] data = new byte[size];
            ThrowErrorIfNotSuccessful(
                SetupDiGetDeviceRegistryPropertyA(
                    deviceInfoSet,
                    ref deviceInfoData,
                    property,
                    out RegistryDataType type,
                    data,
                    size,
                    out uint dummysize)
                );
            return new RegistryData(type, data);
        }
        /// <summary>
        /// Method used to wrap native DLL calls. Throws the last system error when the call is unsuccessful.
        /// </summary>
        /// <param name="success">Return value of the native method. ( Usually used as ThrowErrorIfNotSuccessful(MethodCall()); )</param>
        private static void ThrowErrorIfNotSuccessful(bool success) {
            if (!success) {
                throw new Exception("Native method call error: " + Marshal.GetLastWin32Error().ToString());
            }
        }
