    public void CreateWaveForm(string audioFilePath, string audioWaveFormFilePath)
        {
            try
            {
                int bytesPerSample = 0;
                using (NAudio.Wave.Mp3FileReader reader = new NAudio.Wave.Mp3FileReader(audioFilePath, wf => new NAudio.FileFormats.Mp3.DmoMp3FrameDecompressor(wf)))
                {
                    using (NAudio.Wave.WaveChannel32 channelStream = new NAudio.Wave.WaveChannel32(reader))
                    {
                        bytesPerSample = (reader.WaveFormat.BitsPerSample / 8) * channelStream.WaveFormat.Channels;
                        //Give a size to the bitmap; either a fixed size, or something based on the length of the audio
                        using (Bitmap bitmap = new Bitmap((int)Math.Round(reader.TotalTime.TotalSeconds * 40), 200))
                        {
                            int width = bitmap.Width;
                            int height = bitmap.Height;
                            using (Graphics graphics = Graphics.FromImage(bitmap))
                            {
                                graphics.Clear(Color.White);
                                Pen bluePen = new Pen(Color.Blue);
                                int samplesPerPixel = (int)(reader.Length / (double)(width * bytesPerSample));
                                int bytesPerPixel = bytesPerSample * samplesPerPixel;
                                int bytesRead;
                                byte[] waveData = new byte[bytesPerPixel];
                                for (float x = 0; x < width; x++)
                                {
                                    bytesRead = reader.Read(waveData, 0, bytesPerPixel);
                                    if (bytesRead == 0)
                                        break;
                                    short low = 0;
                                    short high = 0;
                                    for (int n = 0; n < bytesRead; n += 2)
                                    {
                                        short sample = BitConverter.ToInt16(waveData, n);
                                        if (sample < low) low = sample;
                                        if (sample > high) high = sample;
                                    }
                                    float lowPercent = ((((float)low) - short.MinValue) / ushort.MaxValue);
                                    float highPercent = ((((float)high) - short.MinValue) / ushort.MaxValue);
                                    float lowValue = height * lowPercent;
                                    float highValue = height * highPercent;
                                    graphics.DrawLine(bluePen, x, lowValue, x, highValue);
                                }
                            }
                            bitmap.Save(audioWaveFormFilePath);
                        }
                    }
                }
            }
            catch
            {
            }
        }
