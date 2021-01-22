    static void Iterate(byte[] arr, Action<byte[]> action) {
        var i = 0;
        action(arr);
        while (i < arr.Length)
        {
            if (++arr[i] != 0)
            {
                i = 0;
                action(arr);
            }
            else i++;
        }
               
    }
    static void Main(string[] args)
    {
        var bytes = new byte[2];
        Iterate(bytes, arr => {
            Console.Write(String.Join(",", arr.Select(x=>$"{x:D3}")));
            Console.WriteLine();
        });
    }
