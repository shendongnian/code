    	public byte[] ShiftRight(byte[] value, int bitcount)
		{
			byte[] temp = new byte[value.Length];
			if (bitcount >= 8)
			{
				Array.Copy(value, 0, temp, bitcount / 8, temp.Length - (bitcount / 8));
			}
			else
			{
				Array.Copy(value, temp, temp.Length);
			}
			if (bitcount % 8 != 0)
			{
				for (int i = temp.Length - 1; i >= 0; i--)
				{
					temp[i] >>= bitcount % 8;
					if (i > 0)
					{
						temp[i] |= (byte)(temp[i - 1] << 8 - bitcount % 8);
					}
				}
			}
			return temp;
		}
