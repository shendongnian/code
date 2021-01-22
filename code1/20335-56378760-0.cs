00-aa-84-fb
12 32 FF CD
12 00
12_32_FF_CD
1200d5e68a
/// <summary>Reads a hex string into bytes</summary>
public static IEnumerable<byte> HexadecimalStringToBytes(string hex) {
	if (hex == null)
		throw new ArgumentNullException(nameof(hex));
	char c, c1 = default(char);
	bool hasc1 = false;
	unchecked 	{
		for (int i = 0; i < hex.Length; i++) {
			c = hex[i];
			bool isValid = 'A' <= c && c <= 'f' || 'a' <= c && c <= 'f' || '0' <= c && c <= '9';
			if (!hasc1) {
				if (isValid) {
					hasc1 = true;
				}
			} else {
				hasc1 = false;
				if (isValid) {
					yield return (byte)((GetHexVal(c1) << 4) + GetHexVal(c));
				}
			}
			c1 = c;
		} 
	}
}
/// <summary>Reads a hex string into a byte array</summary>
public static byte[] HexadecimalStringToByteArray(string hex)
{
	if (hex == null)
		throw new ArgumentNullException(nameof(hex));
	var bytes = new List<byte>(hex.Length / 2);
	foreach (var item in HexadecimalStringToBytes(hex)) {
		bytes.Add(item);
	}
	return bytes.ToArray();
}
private static byte GetHexVal(char val)
{
	return (byte)(val - (val < 0x3A ? 0x30 : val < 0x5B ? 0x37 : 0x57));
	//                   ^^^^^^^^^^^^^^^^^   ^^^^^^^^^^^^^^^^^   ^^^^
	//                       digits 0-9       upper char A-Z     a-z
}
Please refer to [full code](https://gist.github.com/sandrock/f38cf1b56a16e4d684398ac2117069ce) when copying. Unit tests included.
Some might say it is too much tolerant to extra chars. So don't rely on this code to perform validation (or change it).
