			ushort[] data = inData; // The ushort array source
			
			Byte[] bytes = new Byte[data.Length];  // Assumption - only need one byte per ushort
			
			int i = 0;
			foreach(ushort x in data) {
				byte[] tmp = System.BitConverter.GetBytes(x);
				bytes[i++] = tmp[0];
				// Note: not using tmp[1] as all characters in 0 < x < 127 use one byte.
			}
			String str = Encoding.ASCII.GetString(bytes);
