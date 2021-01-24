	[Flags]
	public enum PacketFlags : ushort
	{
		None = 0x1,  // this is the same as 1 << 1 = 1
		Nat = 0x2,   // this is the same as 1 << 2 = 2
		Hb = 0x4,    // this is the same as 1 << 3 = 4
		Dat = 0x8,
		Dscvr = 0x10,
		Status = 0x20,  // this is the same as 1 << 6 = 32
		Conn = 0x40,
		Finn = 0x80,
	}
