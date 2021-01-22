string text = "Test";
byte[] bytes = System.Text.Encoding.ASCII.GetBytes(text);
BitArray bits = new BitArray(bytes);
bytes[] bytesBack = BitArrayToByteArray(bits);
string textBack = System.Text.Encoding.ASCII.GetString(bytesBack);
// bytes == bytesBack
// text = textBack
.
