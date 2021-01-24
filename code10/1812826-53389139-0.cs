    case "uint32":
				{
					if (varBytes.Count == 1)
					{
						varReady = (UInt32)varBytes[0];
					}
					else if (varBytes.Count >= 2 && varBytes.Count <= 4)
					{
						varReady = (UInt32)BitConverter.ToUInt16(varBytes.ToArray<byte>(), 0);
					}
					else
					{
						varReady = BitConverter.ToUInt32(varBytes.ToArray<byte>(), 0);
					}
					break;
				}
