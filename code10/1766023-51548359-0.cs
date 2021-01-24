                byte[] Packet = new byte[4096];
                string b64str = "";
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    int i = Packet.Length;
                    while (i == Packet.Length)
                    {
                        i = fs.Read(Packet, 0, Packet.Length);
                        b64str = Convert.ToBase64String(Packet, 0, i);
                    }
                }
