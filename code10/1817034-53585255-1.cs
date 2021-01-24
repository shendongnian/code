    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Media;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using NAudio.Wave;
    
    
    public class UDPListener
    {
        uint current_recv_data_buf;
        static int NB_DATA_BUFS = 5;
        static UInt16[] data_buf = new UInt16[700];
    
        uint current_play_data_buf; // current data buf being played
        uint play_data_buf_pos; // position in the ADC data buffer
    
    
        private const int listenPort = 45990;
    
    
    
        public static unsafe int Main()
        {
            bool done = false;
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Parse("192.168.1.3"), listenPort);
            int BUFSIZE = 700;
            byte[] receive_byte_array;
            uint current_recv_data_buf = 1;
            List<byte> tenBuffsToPlay = new List<byte>();
            int iterBuffsToPLay = 0;
            byte[] byteArrToPlay = new byte[data_buf.Length * 2];
            byte[] byte10ArrToPlay;
            int pktcount = 0;
    
            var sampleRate = 20000;
            var frequency = 500;
            var amplitude = 0.2;
            var seconds = 5;
    
            while (!done)
            {
                receive_byte_array = listener.Receive(ref groupEP);
                if (receive_byte_array.Length > 0)
                {
                    Console.WriteLine("received !"+pktcount++);
                    int sz = receive_byte_array.Length;
                    unsafe
                    {
    
                        byte[] buf = new byte[sz];
    
                        buf = receive_byte_array;
                       fixed (UInt16* data_bufPtr = &data_buf[0])
                       fixed (byte* ptrbuf = buf)
                       do_undelta7(ptrbuf, sz, data_bufPtr);
    
                        //string firstPart = "";
                        //string secondPart = "";
    
                        for (int i =0;i<data_buf.Length;i++)
                        {
                            //Console.WriteLine("Hex: {0:X}", data_buf[i]);
                            
                            byteArrToPlay[i*2] = (byte)((data_buf[i] >> 8)&0x0f);
                            byteArrToPlay[(i*2)+1] = (byte)(data_buf[i] & 0xff);
                            //firstPart = Convert.ToString(byteArrToPlay[i], 2).PadLeft(4, '0');
                            //Console.Write(firstPart);
                            //secondPart = Convert.ToString(byteArrToPlay[i+1], 2).PadLeft(4, '0');
                            //Console.Write(secondPart+"\n");
                        }
    
                        //byteArrToPlay = data_buf.SelectMany(BitConverter.GetBytes).ToArray();
    
                        //foreach (var Arr in byteArrToPlay)
                        // {
                        // Console.WriteLine("Hex: {0:X}", Arr);
                        // }
                        tenBuffsToPlay.AddRange(byteArrToPlay);
                        iterBuffsToPLay++;
                        if (iterBuffsToPLay == 3)
                        {
                            byte10ArrToPlay = tenBuffsToPlay.ToArray();
    
    
                            /*var raw = new byte[sampleRate * seconds * 2];
    
                            var multiple = 2.0 * frequency / sampleRate;
                            for (int n = 0; n < sampleRate * seconds; n++)
                            {
                                var sampleSaw = ((n * multiple) % 2) - 1;
                                var sampleValue = sampleSaw > 0 ? amplitude : -amplitude;
                                var sample = (short)(sampleValue * Int16.MaxValue);
                                var bytes = BitConverter.GetBytes(sample);
                                raw[n * 2] = bytes[0];
                                raw[n * 2 + 1] = bytes[1];
                            }*/
                          
    
                            var ms = new MemoryStream(byte10ArrToPlay);
                            var rs = new RawSourceWaveStream(ms, new WaveFormat(sampleRate, 16, 1));
    
    
                            var wo = new WaveOutEvent();
                            wo.Init(rs);
                            wo.Play();
                            /*while (wo.PlaybackState == PlaybackState.Playing)
                            {
                                Thread.Sleep(1);
                            }*/
                            //wo.Dispose();
    
    
    
    
    
    
                            
                            /*using (MemoryStream ms = new MemoryStream())
                            {
                                WriteWavHeader(ms, false, 1, 16, 20000, (byte10ArrToPlay.Length / 2 - 45));
                                // Construct the sound player
                                ms.Write(byte10ArrToPlay, 0, byte10ArrToPlay.Length);
                                ms.Position = 0;
                                SoundPlayer player = new SoundPlayer(ms);
                                player.Play();
                            }*/
                            tenBuffsToPlay.Clear();
                           iterBuffsToPLay = 0;
                        }
    
                    }
    
                }
            }
    
            listener.Close();
            return 0;
        }
    
    
        static unsafe long do_undelta7(byte* val, int sz, UInt16* outArray)
        {
            // Implement delta 7 decompression.
            // First bit = 0 <=> uncompressed 15 bits following 
            // First bit = 1 <=> 7 bits follow representing delta
            // must switch to big endian...
            UInt16 last = 0;
            byte* ptr = (byte*)&outArray[0];
            byte* start = ptr;
            for (int i = 0; i < sz; i++)
            {
                UInt16* ptr16 = (UInt16*)ptr;
                byte firstbyte = val[i];
                var bit = (firstbyte & (1 << 8 - 1)) != 0;
                if (bit == true)
                {
                    // Delta7 compressed
                    // byte is CSMMMMMM
                    sbyte delta = (sbyte)(firstbyte & 0x3f);
                    bit = (firstbyte & (1 << 7 - 1)) != 0;
                    if (bit == true)
                    {
                        delta = (sbyte)(0x0 - delta);
                    }
                    UInt16 value = (UInt16)(last + delta);
                    *ptr16 = value;
                    ptr += 2;
    
                    last = value;
                }
                else
                {
                    // uncompressed -- switch bytes back to LE
                    
                    *ptr++ = val[i + 1];
                    *ptr++ = val[i];
                    last = (UInt16)(val[i + 1] | val[i] << 8);
                    i++;
                }
            }
    
            return ptr - start;
    
        }
        private static void WriteWavHeader(MemoryStream stream, bool isFloatingPoint, ushort channelCount, ushort bitDepth, int sampleRate, int totalSampleCount)
        {
            stream.Position = 0;
            stream.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);
            stream.Write(BitConverter.GetBytes((2* totalSampleCount) + 36), 0, 4);
            stream.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);
            stream.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);
            stream.Write(BitConverter.GetBytes(16), 0, 4);
            stream.Write(BitConverter.GetBytes((ushort)(isFloatingPoint ? 3 : 1)), 0, 2);
            stream.Write(BitConverter.GetBytes(channelCount), 0, 2);
            stream.Write(BitConverter.GetBytes(sampleRate), 0, 4);
            stream.Write(BitConverter.GetBytes(sampleRate * 2), 0, 4);
            stream.Write(BitConverter.GetBytes((ushort)2), 0, 2);
            stream.Write(BitConverter.GetBytes(16), 0, 2);
            stream.Write(Encoding.ASCII.GetBytes("data"), 0, 4);
            stream.Write(BitConverter.GetBytes(2 * totalSampleCount), 0, 4);
        }
    
    
    } // end of class UDPListener
