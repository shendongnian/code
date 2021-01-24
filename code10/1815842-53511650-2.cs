	[Flags]
	public enum PacketFlags : ushort
	{
		None   = 0x01,  // this is the same as 1 << 1 = 1
		Nat    = 0x02,  // this is the same as 1 << 2 = 2
		Hb     = 0x04,  // this is the same as 1 << 3 = 4
		Dat    = 0x08,
		Dscvr  = 0x10,
		Status = 0x20,  // this is the same as 1 << 6 = 32
		Conn   = 0x40,
		Finn   = 0x80,
	}
