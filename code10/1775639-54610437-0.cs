	public static class SerialAsyncExtensions
    {
		public static async Task<int> ReadSerialAsync(this SerialPort f_Serial, byte[] f_Buffer, int f_Offset, int f_Count, int f_Delay)
        {
            if (f_Delay > 0)
                await Task.Delay(f_Delay);
            return await f_Serial.BaseStream.ReadAsync(f_Buffer, f_Offset, f_Count);
        }
        public static async Task<int> ReadSerialAsync(this SerialPort f_Serial, byte[] f_Buffer, int f_Offset, int f_Count, int f_Delay, CancellationToken f_Token)
        {
            CancellationTokenRegistration l_Token_Registration = f_Token.Register((param) =>
            {
                SerialPort l_Serial = (SerialPort)param;
                bool l_Was_Open = l_Serial.IsOpen;
                l_Serial.BaseStream.Close();
                if (l_Was_Open) l_Serial.Open();
            }, f_Serial);
            if (f_Delay > 0)
                await Task.Delay(f_Delay, f_Token);
            try
            {
                int l_Result = await f_Serial.BaseStream.ReadAsync(f_Buffer, f_Offset, f_Count, f_Token);
                return l_Result;
            }
            catch(System.IO.IOException Ex)
            {
                throw new OperationCanceledException("ReadSerialAsync operation Cancelled.", Ex);
            }
            finally
            {
                l_Token_Registration.Dispose();
            }
        }
        public static async Task WriteSerialAsync(this SerialPort f_Serial, byte[] f_Buffer, int f_Offset, int f_Count)
        {
            await f_Serial.BaseStream.WriteAsync(f_Buffer, f_Offset, f_Count);
        }
        public static async Task WriteSerialAsync(this SerialPort f_Serial, byte[] f_Buffer, int f_Offset, int f_Count, CancellationToken f_Token)
        {
            CancellationTokenRegistration l_Token_Registration = f_Token.Register((param) =>
            {
                SerialPort l_Serial = (SerialPort)param;
                bool l_Was_Open = l_Serial.IsOpen;
                l_Serial.BaseStream.Close();
                if (l_Was_Open) l_Serial.Open();
            }, f_Serial);
            try
            {
                await f_Serial.BaseStream.WriteAsync(f_Buffer, f_Offset, f_Count, f_Token);
            }
            catch(System.IO.IOException Ex)
            {
                throw new OperationCanceledException("WriteSerialAsync operation Cancelled.", Ex);
            }
            finally
            {
                l_Token_Registration.Dispose();
            }
        }
	}
