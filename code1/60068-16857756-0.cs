        public void ProcessRawContents(string raw)
        {
            // NB: empty lines may be relevant for interpretation and for content !!
            var lRawLines = raw.Split(new []{"\r\n"}, StringSplitOptions.None);
            var lMailReader = new MimeReader(lRawLines);
            var lMimeEntity = lMailReader.CreateMimeEntity();
            MailMessageEx Email = lMimeEntity.ToMailMessageEx();
            // ...
        }
