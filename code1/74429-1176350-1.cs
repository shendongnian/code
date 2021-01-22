    Basic: 2342ms
    Custom: 1319ms
---
    using System.Diagnostics;
    using System;
    using System.IO;
    static class Program
    {
        static void Main()
        {
            DateTime when = DateTime.Now;
            const int LOOP = 1000000;
    
            Stopwatch basic = Stopwatch.StartNew();
            using (TextWriter tw = new StreamWriter("basic.txt"))
            {
                for (int i = 0; i < LOOP; i++)
                {
                    tw.Write(when.ToString("dd.MM.yy HH:mm:ss:fff"));
                }
            }
            basic.Stop();
            Console.WriteLine("Basic: " + basic.ElapsedMilliseconds + "ms");
    
            char[] buffer = new char[100];
            Stopwatch custom = Stopwatch.StartNew();
            using (TextWriter tw = new StreamWriter("custom.txt"))
            {
                for (int i = 0; i < LOOP; i++)
                {
                    WriteDateTime(tw, when, buffer);
                }
            }
            custom.Stop();
            Console.WriteLine("Custom: " + custom.ElapsedMilliseconds + "ms");
        }
        static void WriteDateTime(TextWriter output, DateTime when, char[] buffer)
        {
            buffer[2] = buffer[5] = '.';
            buffer[8] = ' ';
            buffer[11] = buffer[14] = buffer[17] = ':';
            Write2(buffer, when.Day, 0);
            Write2(buffer, when.Month, 3);
            Write2(buffer, when.Year % 100, 6);
            Write2(buffer, when.Hour, 9);
            Write2(buffer, when.Minute, 12);
            Write2(buffer, when.Second, 15);
            Write3(buffer, when.Millisecond, 18);
            output.Write(buffer, 0, 21);
        }
        static void Write2(char[] buffer, int value, int offset)
        {
            buffer[offset++] = (char)('0' + (value / 10));
            buffer[offset] = (char)('0' + (value % 10));
        }
        static void Write3(char[] buffer, int value, int offset)
        {
            buffer[offset++] = (char)('0' + (value / 100));
            buffer[offset++] = (char)('0' + ((value / 10) % 10));
            buffer[offset] = (char)('0' + (value % 10));
        }
    }
