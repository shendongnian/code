			byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			int byteCount = bytes.Length;
			unsafe
			{
				fixed (byte* bytePointer = bytes)
				{
					short* shortPointer = (short*)bytePointer;
					for (int index = 0; index < byteCount / 2; index++)
					{
						Console.WriteLine("Short {0}: {1}", index, shortPointer[index]);
					}
				}
			}
