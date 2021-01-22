    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web.Services.Protocols;
    using System.Xml;
    
    using Test.MyWebReference;
    
    namespace Test {
        /// <summary>
        /// Adds the ability to retrieve the SOAP request/response.
        /// </summary>
        public class ServiceSpy : OriginalService {
            private StreamSpy writerStreamSpy;
            private XmlTextWriter xmlWriter;
    
            private StreamSpy readerStreamSpy;
            private XmlTextReader xmlReader;
    
            public MemoryStream WriterStream {
                get { return writerStreamSpy == null ? null : writerStreamSpy.ClonedStream; }
            }
    
            public XmlTextWriter XmlWriter {
                get { return xmlWriter; }
            }
    
            public MemoryStream ReaderStream {
                get { return readerStreamSpy == null ? null : readerStreamSpy.ClonedStream; }
            }
    
            public XmlTextReader XmlReader {
                get { return xmlReader; }
            }
    
            protected override void Dispose(bool disposing) {
                base.Dispose(disposing);
                DisposeWriterStreamSpy();
                DisposeReaderStreamSpy();
            }
    
            protected override XmlWriter GetWriterForMessage(SoapClientMessage message, int bufferSize) {
                // Dispose previous writer stream spy.
                DisposeWriterStreamSpy();
    
                writerStreamSpy = new StreamSpy(message.Stream);
                // XML should always support UTF8.
                xmlWriter = new XmlTextWriter(writerStreamSpy, Encoding.UTF8);
    
                return xmlWriter;
            }
    
            protected override XmlReader GetReaderForMessage(SoapClientMessage message, int bufferSize) {
                // Dispose previous reader stream spy.
                DisposeReaderStreamSpy();
    
                readerStreamSpy = new StreamSpy(message.Stream);
                xmlReader = new XmlTextReader(readerStreamSpy);
    
                return xmlReader;
            }
    
            private void DisposeWriterStreamSpy() {
                if (writerStreamSpy != null) {
                    writerStreamSpy.Dispose();
                    writerStreamSpy.ClonedStream.Dispose();
                    writerStreamSpy = null;
                }
            }
    
            private void DisposeReaderStreamSpy() {
                if (readerStreamSpy != null) {
                    readerStreamSpy.Dispose();
                    readerStreamSpy.ClonedStream.Dispose();
                    readerStreamSpy = null;
                }
            }
    
            /// <summary>
            /// Wrapper class to clone read/write bytes.
            /// </summary>
            public class StreamSpy : Stream {
                private Stream wrappedStream;
                private long startPosition;
                private MemoryStream clonedStream = new MemoryStream();
    
                public StreamSpy(Stream wrappedStream) {
                    this.wrappedStream = wrappedStream;
                    startPosition = wrappedStream.Position;
                }
    
                public MemoryStream ClonedStream {
                    get { return clonedStream; }
                }
    
                public override bool CanRead {
                    get { return wrappedStream.CanRead; }
                }
    
                public override bool CanSeek {
                    get { return wrappedStream.CanSeek; }
                }
    
                public override bool CanWrite {
                    get { return wrappedStream.CanWrite; }
                }
    
                public override void Flush() {
                    wrappedStream.Flush();
                }
    
                public override long Length {
                    get { return wrappedStream.Length; }
                }
    
                public override long Position {
                    get { return wrappedStream.Position; }
                    set { wrappedStream.Position = value; }
                }
    
                public override int Read(byte[] buffer, int offset, int count) {
                    long relativeOffset = wrappedStream.Position - startPosition;
                    int result = wrappedStream.Read(buffer, offset, count);
                    if (clonedStream.Position != relativeOffset) {
                        clonedStream.Position = relativeOffset;
                    }
                    clonedStream.Write(buffer, offset, result);
                    return result;
                }
    
                public override long Seek(long offset, SeekOrigin origin) {
                    return wrappedStream.Seek(offset, origin);
                }
    
                public override void SetLength(long value) {
                    wrappedStream.SetLength(value);
                }
    
                public override void Write(byte[] buffer, int offset, int count) {
                    long relativeOffset = wrappedStream.Position - startPosition;
                    wrappedStream.Write(buffer, offset, count);
                    if (clonedStream.Position != relativeOffset) {
                        clonedStream.Position = relativeOffset;
                    }
                    clonedStream.Write(buffer, offset, count);
                }
    
                public override void Close() {
                    wrappedStream.Close();
                    base.Close();
                }
    
                protected override void Dispose(bool disposing) {
                    if (wrappedStream != null) {
                        wrappedStream.Dispose();
                        wrappedStream = null;
                    }
                    base.Dispose(disposing);
                }
            }
        }
    }
