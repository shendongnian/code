    protected static FlowDocument LoadRemoteRtf(string path)
        {
            var doc = new FlowDocument();
            if (!string.IsNullOrEmpty(path))
            {
                var range = new TextRange(doc.ContentStart, doc.ContentEnd);
                var downloader = new WebClient();
                Stream stream = null;
                try
                {
                    stream = downloader.OpenRead(path);
                    range.Load(stream, DataFormats.Rtf);
                }
                catch (Exception ex)
                {
                    var props = new Dictionary<string, object> {{"URL", path}};
                    Logging.WriteLogEntry("Failed to load remote RTF document.", ex, TraceEventType.Information, props);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    downloader.Dispose();
                }
            }
            return doc;
        }
    MyRTB.Document = LoadRemoteRtf("http://myserver.com/docs/remote.rtf");
