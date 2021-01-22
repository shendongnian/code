        void SetKeepAlive(bool on, uint keepAliveTime , uint keepAliveInterval )
        {
            int size = Marshal.SizeOf(new uint());
            var inOptionValues = new byte[size * 3];
            BitConverter.GetBytes((uint)(on ? 1 : 0)).CopyTo(inOptionValues, 0);
            BitConverter.GetBytes((uint)time).CopyTo(inOptionValues, size);
            BitConverter.GetBytes((uint)interval).CopyTo(inOptionValues, size * 2);
            socket.IOControl(IOControlCode.KeepAliveValues, inOptionValues, null);
        }
