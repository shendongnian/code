	using System;
	using System.Collections.Generic;
	using System.Text;
	namespace VehicleSpeedTracer
	{
		public class Datagram
		{
			//Offsets im ByteArray
			private const int SizeOffset = 0;
			private const int TimeOffset = SizeOffset + sizeof(uint);
			private const int SpeedOffset = TimeOffset + sizeof(double);
			private const int UnitOffset = SpeedOffset + sizeof(char);
			private const int UnitMaxSize = (int)MaxSize - UnitOffset;
			//Daten Current
			public const uint MaxSize = 128;
			public TimeSpan CurrentTime;
			public double CurrentSpeed;
			public string Unit;
			public uint Size
			{
				get { return MaxSize - (uint)UnitMaxSize + (uint)Unit.Length; }
			}
			public Datagram()
			{
			}
			public Datagram(Datagram Data)
			{
				CurrentTime = Data.CurrentTime;
				CurrentSpeed = Data.CurrentSpeed;
				Unit = Data.Unit;
			}
			public Datagram(byte[] RawData)
			{
				CurrentTime = TimeSpan.FromSeconds(GetDouble(RawData, TimeOffset));
				CurrentSpeed = GetDouble(RawData, SpeedOffset);
				Unit = GetString(RawData, UnitOffset, (int)(GetUInt(RawData, SizeOffset) - UnitOffset));
			}
			public override string ToString()
			{
				return this.CurrentTime.Hours.ToString().PadLeft(2, '0') + ":" +
						this.CurrentTime.Minutes.ToString().PadLeft(2, '0') + ":" +
						this.CurrentTime.Seconds.ToString().PadLeft(2, '0') + "." +
						this.CurrentTime.Milliseconds.ToString().PadLeft(3, '0') + "  " +
						this.Unit;
			}
			public static implicit operator byte[](Datagram Data)
			{
				byte[] RawData;
				RawData = new byte[Data.Size];
				SetUInt(RawData, SizeOffset, Data.Size);
				SetDouble(RawData, TimeOffset, Data.CurrentTime.TotalDays);
				SetDouble(RawData, SpeedOffset, Data.CurrentSpeed);
				SetString(RawData, UnitOffset, Data.Unit);
				return RawData;
			}
			#region Utility Functions
			// utility:  get a uint from the byte array
			private static uint GetUInt(byte[] aData, int Offset)
			{
				return BitConverter.ToUInt32(aData, Offset);
			}
			// utility:  set a uint into the byte array
			private static void SetUInt(byte[] aData, int Offset, uint Value)
			{
				byte[] buint = BitConverter.GetBytes(Value);
				Buffer.BlockCopy(buint, 0, aData, Offset, buint.Length);
			}
			// utility:  get a ushort from the byte array
			private static ushort GetUShort(byte[] aData, int Offset)
			{
				return BitConverter.ToUInt16(aData, Offset);
			}
			// utility:  set a ushort into the byte array
			private static void SetUShort(byte[] aData, int Offset, int Value)
			{
				byte[] bushort = BitConverter.GetBytes((short)Value);
				Buffer.BlockCopy(bushort, 0, aData, Offset, bushort.Length);
			}
			// utility:  get a double from the byte array
			private static double GetDouble(byte[] aData, int Offset)
			{
				return BitConverter.ToDouble(aData, Offset);
			}
			// utility:  set a double into the byte array
			private static void SetDouble(byte[] aData, int Offset, double Value)
			{
				byte[] bushort = BitConverter.GetBytes(Value);
				Buffer.BlockCopy(bushort, 0, aData, Offset, bushort.Length);
			}
			// utility:  get a unicode string from the byte array
			private static string GetString(byte[] aData, int Offset, int Length)
			{
				String sReturn = Encoding.ASCII.GetString(aData, Offset, Length);
				return sReturn;
			}
			// utility:  set a unicode string in the byte array
			private static void SetString(byte[] aData, int Offset, string Value)
			{
				byte[] arr = Encoding.ASCII.GetBytes(Value);
				Buffer.BlockCopy(arr, 0, aData, Offset, arr.Length);
			}
			#endregion
		}
		public delegate void DatagramEventHandler(object sender, DatagramEventArgs e);
		public class DatagramEventArgs : EventArgs
		{
			public Datagram Data;
			public DatagramEventArgs(Datagram Data)
			{
				this.Data = Data;
			}
		}
	}
