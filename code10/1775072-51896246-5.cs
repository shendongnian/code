    public class KeySenderDemo
    {
        private static Random random = new Random();
    
        private KeySender ks;
        private bool _deleting = true;
    
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    
        public string DefaultKeysToSend()
        {
            return (_deleting = !_deleting) ? "{BACKSPACE}" : RandomString(1);
        }
    
        public void Stop()
        {
            if (ks != null) ks.StopSendingKeys();
            ks = null;
        }
    
        public KeySenderDemo()
        {
            Form f = new Form();
            TextBox tb = new TextBox();
            tb.Parent = f;
            tb.Location = new Point(10, 10);
            tb.Size = new Size(200, 16);
            f.Load += (s, e) =>
            {
                tb.Focus();
                ks = new KeySender(tb.Handle, DefaultKeysToSend);
                ks.StartSendingKeys(1, 200);
            };
            f.Click += (s, e) =>
            {
               if (ks.Sending()) ks.StopSendingKeys();
                else
                {
                    tb.Focus();
                    ks.StartSendingKeys(1, 200);
                }
            };
            Application.Run(f);
        }
       }
