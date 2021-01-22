       using(Mp3FileReader reader = new Mp3FileReader(@"path\to\MP3")) {
            using(WaveFileWriter writer = new WaveFileWriter(@"C:\test.wav", new WaveFormat())) {
                byte buf = new byte[4096];
                for (;;) {
                    int cnt = reader.Read(buf, 0, buf.Length);
                    if (cnt == 0) break;
                    writer.WriteData(buf, 0, cnt);
                }
            }
        }
