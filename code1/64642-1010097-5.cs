                //string chopMe = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                //int partLength = 12;
                //Stopwatch sw = new Stopwatch();
                sw = Stopwatch.StartNew();
                string s = chopMe;
                StringBuilder n = new StringBuilder();
                int chopSize = 0;
                int pos = 0;
                while (pos < s.Length )
                {
                    chopSize = (pos + partLength);
                    chopSize = chopSize < s.Length ? partLength : s.Length - pos;
                    n.Append(s, pos, chopSize);
                    n.Append("\r\n");
                    pos += chopSize;
                }
                
                sw.Stop();
                Debug.WriteLine(sw.ElapsedTicks);
