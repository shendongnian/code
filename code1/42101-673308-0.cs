            FileStream fs = new FileStream(@"C:\Sample.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] data;
            using (BinaryReader br = new BinaryReader(fs))
            {
                data = br.ReadBytes((int)fs.Length);
            }
            Console.WriteLine(Encoding.UTF8.GetString(data));
            Console.WriteLine(Encoding.UTF7.GetString(data));
            Console.WriteLine(Encoding.ASCII.GetString(data));
