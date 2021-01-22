			byte[] byteData = new byte[] { 0xa0, 0x14, 0x72, 0xbf, 0x72, 0x3c, 0x21 };
			Type[] types = new Type[] {typeof(int),typeof(short),typeof(sbyte)};
			
			object[] primitiveData = new object[types.Length];
			int sp = 0;
			
			for(int i=0; i<types.Length; i++)
			{
				string s = types[i].FullName;
				switch(types[i].FullName)
				{
					case "System.Int32":{
						primitiveData[i] = BitConverter.ToInt32(byteData, sp);
						sp += 4;
					}break;
					case "System.Int16":
						{
						primitiveData[i] = BitConverter.ToInt16(byteData, sp);
						sp += 2;
					}break;
					case "System.SByte":
						{
						primitiveData[i] = (sbyte)byteData[sp];
						sp += 1;
					}break;
				}
			}
