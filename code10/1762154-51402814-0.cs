    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    namespace IS.Framework.Logging
    {
        public static class FileLogger
        {
            public static bool IsStarted { get; private set; }
            public static Encoding Encoding { get; private set; }
            public static string LogFilePath { get; private set; }
    
            private static FileStream FS;
            private static int BytesPerChar;
            private static readonly object Locker = new object();
    
            public static void Start(string logFilePath, Encoding encoding = null)
            {
                lock (Locker)
                {
                    if (IsStarted) return;
                    LogFilePath = logFilePath;
                    Encoding = encoding ?? Encoding.UTF8;
                    if (File.Exists(LogFilePath)) File.SetAttributes(LogFilePath, FileAttributes.Normal);
                    FS = new FileStream(LogFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 4096, FileOptions.RandomAccess);
                    FS.SetLength(0);
                    FS.Flush();
                    BytesPerChar = Encoding.UTF8.GetByteCount(new[] { 'A' });
                    IsStarted = true;
                }
            }
    
            public static void Close()
            {
                lock (Locker)
                {
                    if (!IsStarted) return;
                    try { FS?.Close(); } catch { }
                    FS = null;
                    IsStarted = false;
                }
            }
    
            public static void WriteToFile(string text)
            {
                lock (Locker)
                {
                    if (string.IsNullOrEmpty(text)) return;
    
                    if (!text.Contains('\b'))
                    {
                        FS.Position = FS.Length;
                        byte[] bytes = Encoding.GetBytes(text);
                        FS.Write(bytes, 0, bytes.Length);
                        FS.Flush();
                        return;
                    }
    
                    // Evaluates the the string into initial backspaces and remaining text to be appended:
                    EvaluateText(text, out int initialBackspaces, out string remainingText);
    
                    // If there are no initial backspaces after evaluating the string, just append it and return:
                    if (initialBackspaces <= 0)
                    {
                        if (string.IsNullOrEmpty(remainingText)) return;
    
                        FS.Position = FS.Length;
                        byte[] bytes = Encoding.GetBytes(remainingText);
                        FS.Write(bytes, 0, bytes.Length);
                        FS.Flush();
                        return;
                    }
    
                    // First process the initial backspaces:
                    long pos = FS.Length - initialBackspaces * BytesPerChar;
                    FS.Position = pos > 0 ? pos : 0;
                    FS.SetLength(FS.Position);
    
                    // Then write any remaining evaluated text:
                    if (!string.IsNullOrEmpty(remainingText))
                    {
                        byte[] bytes = Encoding.GetBytes(remainingText);
                        FS.Write(bytes, 0, bytes.Length);
                    }
                    FS.Flush();
                    return;
                }
            }
    
            public static void EvaluateText(string text, out int initialBackspaces, out string remainingTextToAppend)
            {
                initialBackspaces = 0;
                StringBuilder sb = new StringBuilder();
                foreach (char ch in text)
                {
                    if(ch == '\b')
                    {
                        if (sb.Length > 0) sb.Length--;
                        else initialBackspaces++;
                    }
                    else sb.Append(ch);
                }
                remainingTextToAppend = sb.ToString();
            }
        }
    }
