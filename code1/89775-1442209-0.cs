    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    namespace Ionic.Kewl
    {
        public class HTTPRangeStream : Stream
        {
            private string url;
            private long length;
            private long position;
            private long totalBytesRead;
            private int totalReads;
            public HTTPRangeStream(string URL)
            {
                url = URL;
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse result = (HttpWebResponse)request.GetResponse();
                length = result.ContentLength;
            }
            public long TotalBytesRead    { get { return totalBytesRead; } }
            public long TotalReads        { get { return totalReads; } }
            public override bool CanRead  { get { return true; } }
            public override bool CanSeek  { get { return true; } }
            public override bool CanWrite { get { return false; } }
            public override long Length   { get { return length; } }
            public override bool CanTimeout
            {
                get
                {
                    return base.CanTimeout;
                }
            }
            public override long Position
            {
                get
                {
                    return position;
                }
                set
                {
                    if (value < 0) throw new ArgumentException();
                    position = value;
                }
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                switch (origin)
                {
                    case SeekOrigin.Begin:
                        position = offset;
                        break;
                    case SeekOrigin.Current:
                        position += offset;
                        break;
                    case SeekOrigin.End:
                        position = Length + offset;
                        break;
                    default:
                        break;
                }
                return Position;
            }
            public override int Read(byte[] buffer, int offset, int count)
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.AddRange(Convert.ToInt32(position), Convert.ToInt32(position) + count);
                HttpWebResponse result = (HttpWebResponse)request.GetResponse();
                using (Stream stream = result.GetResponseStream())
                {
                    stream.Read(buffer, offset, count);
                    stream.Close();
                }
                totalBytesRead += count;
                totalReads++;
                Position += count;
                return count;
            }
            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }
            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
            public override void Flush()
            {
                throw new NotSupportedException();
            }
        }
    }
