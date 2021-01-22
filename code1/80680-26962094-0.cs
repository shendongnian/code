	public static class Int32Extension
	{
		/// <summary>
		/// Copies to byte array Little Endian: Byte order and sift order are inverted.
		/// </summary>
		/// <param name="source">The integer to convert.</param>
		/// <param name="destination">An arbitrary array of bytes.</param>
		/// <param name="offset">Offset into the desination array.</param>
		public static void CopyToByteArray(this int source, byte[] destination, int offset)
		{
			if (destination == null)
				throw new ArgumentException("Destination array cannot be null");
			// check if there is enough space for all the 4 bytes we will copy
			if (destination.Length < offset + sizeof(int))
				throw new ArgumentException("Not enough room in the destination array");
			for (int i = 0, j = sizeof(int) - 1; i < sizeof(int); i++, --j) {
				destination[offset + i] = (byte) (source >> (8 * j));
			}
		}
		/// <summary>
		/// Copies to byte array Little Endian: Byte order and sift order are the same.
		/// </summary>
		/// <param name="source">The integer to convert.</param>
		/// <param name="destination">An arbitrary array of bytes.</param>
		/// <param name="offset">Offset into the desination array.</param>
		public static void CopyToByteArrayLE(this int source, byte[] destination, int offset)
		{
			if (destination == null)
				throw new ArgumentException("Destination array cannot be null");
			// check if there is enough space for all the 4 bytes we will copy
			if (destination.Length < offset + sizeof(int))
				throw new ArgumentException("Not enough room in the destination array");
			for (int i = 0, j = 0; i < sizeof(int); i++, j++) {
				destination[offset + i] = (byte) (source >> (8 * j));
			}
		}
	}
