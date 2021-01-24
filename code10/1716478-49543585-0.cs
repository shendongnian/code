    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace ConsoleApp5
    {
        class Program
        {
            static void Main (string[] args)
            {
                var ms = new MemoryStream (new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                var sequence = new byte[] { 6, 7, 8 };
                var buffer = new byte[1];
                var queue = new Queue<byte> ();
                int position = 0;
                while (true)
                {
                    int count = ms.Read (buffer, 0, 1);
                    if (count == 0) return;
                    queue.Enqueue (buffer[0]);
                    position++;
                    if (IsSequenceFound (queue, sequence))
                    {
                        Console.WriteLine ("Found sequence at position: " + (position - queue.Count));
                        return;
                    }
                    if (queue.Count == sequence.Length) queue.Dequeue ();
                }
            }
            static bool IsSequenceFound (Queue<byte> queue, byte[] sequence)
            {
                return queue.SequenceEqual (sequence);
                // normal for (int i ...) can be faster
            }
        }
    }
