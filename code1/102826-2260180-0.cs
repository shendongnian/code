            char[] b = new char[1024];
            while (!process.HasExited) {
                int c = process.StandardOutput.Read(b, 0, b.Length);
                context.Response.Write(b, 0, c);
                Thread.Sleep(100);
            }
