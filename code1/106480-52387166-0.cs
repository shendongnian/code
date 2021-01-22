     private void OnChanged(object source, FileSystemEventArgs e)
        {
            string sTabName = Path.GetFileNameWithoutExtension(e.Name);
            string sLastLine = ReadLastLine(e.FullPath);
            if(sLastLine != _dupeCheck)
            {
                TabPage tp = tcLogs.TabPages[sTabName];
                TextBox tbLog = (TextBox)tp.Controls[0] as TextBox;
                tbLog.Invoke(new Action(() => tbLog.AppendText(sLastLine + Environment.NewLine)));
                tbLog.Invoke(new Action(() => tbLog.SelectionStart = tbLog.Text.Length));
                tbLog.Invoke(new Action(() => tbLog.ScrollToCaret()));
                _dupeCheck = sLastLine;
            }
        }
        public static String ReadLastLine(string path)
        {
            return ReadLastLine(path, Encoding.Default, "\n");
        }
        public static String ReadLastLine(string path, Encoding encoding, string newline)
        {
            int charsize = encoding.GetByteCount("\n");
            byte[] buffer = encoding.GetBytes(newline);
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                long endpos = stream.Length / charsize;
                for (long pos = charsize; pos < endpos; pos += charsize)
                {
                    stream.Seek(-pos, SeekOrigin.End);
                    stream.Read(buffer, 0, buffer.Length);
                    if (encoding.GetString(buffer) == newline)
                    {
                        buffer = new byte[stream.Length - stream.Position];
                        stream.Read(buffer, 0, buffer.Length);
                        return encoding.GetString(buffer);
                    }
                }
            }
            return null;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_VSCROLL = 0x115;
        private const int SB_BOTTOM = 7;
        /// <summary>
        /// Scrolls the vertical scroll bar of a multi-line text box to the bottom.
        /// </summary>
        /// <param name="tb">The text box to scroll</param>
        public static void ScrollToBottom(TextBox tb)
        {
            SendMessage(tb.Handle, WM_VSCROLL, (IntPtr)SB_BOTTOM, IntPtr.Zero);
        }
