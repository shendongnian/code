    using System;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;
    class MainClass {
    public static void Main (string[] args) {
            // mock up a byte array from something
            var seedString = String.Join("", Enumerable.Range(0, 1024).Select(x => x.ToString()));
            var byteArrayInput = Encoding.ASCII.GetBytes(seedString);
            var skip = 0;
            var take = 640;
            var total = byteArrayInput.Length;
            var output = new List<byte[]>();
            while (skip + take < total) {
                output.Add(byteArrayInput.Skip(skip).Take(take).ToArray());
                skip += take;
            }
            output.ForEach(c => Console.WriteLine($"chunk: {BitConverter.ToString(c)}"));
        }
    }
