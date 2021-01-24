        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DeviceInfo
        {
            public UInt32 maxScanrate;
            public UInt32 minScanrate;
            public UInt32 maxNumOfPoints;
            public UInt64 deviceTypePart1;
            public UInt64 deviceTypePart2;
            public UInt64 deviceTypePart3;
            public UInt64 deviceTypePart4;
            public string GetDeviceType()
            {
                if (Marshal.SizeOf(this) != 44) throw new InvalidOperationException();
                List<byte> bytes = new List<byte>();
                bytes.AddRange(BitConverter.GetBytes(deviceTypePart1));
                bytes.AddRange(BitConverter.GetBytes(deviceTypePart2));
                bytes.AddRange(BitConverter.GetBytes(deviceTypePart3));
                bytes.AddRange(BitConverter.GetBytes(deviceTypePart4));
                return Encoding.GetEncoding(1252).GetString(bytes.ToArray());
            }
        }
