    public byte[] ShiftLeft(byte[] value, int bitcount)
	{
		byte[] temp = new byte[value.Length];
		if (bitcount >= 8)
		{
			Array.Copy(value, bitcount / 8, temp, 0, temp.Length - (bitcount / 8));
		}
		else
		{
			Array.Copy(value, temp, temp.Length);
		}
		if (bitcount % 8 != 0)
		{
			for (int i = 0; i < temp.Length; i++)
			{
				temp[i] <<= bitcount % 8;
				if (i < temp.Length - 1)
				{
					temp[i] |= (byte)(temp[i + 1] >> 8 - bitcount % 8);
				}
			}
		}
		return temp;
	}
