`C#
int x = 7;
Console.WriteLine(x / 3); // 2
Console.WriteLine(Convert.ToDouble(x) / 3); // 2.3333333333333335
Console.WriteLine((double)x / 3); // 2.3333333333333335
`
*BitConverter* class is useful if you want to transmit the value over the network as a series of bytes; you'd use the `BitConverter.GetBytes()` on the sending side, and BitConverter.To*OriginalType*() on the receiving end.
