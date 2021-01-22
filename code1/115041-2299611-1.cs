        private void MyExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            switch (e.EventType)
            {
                case ZipProgressEventType.Extracting_BeforeExtractEntry:
                ....
                case ZipProgressEventType.Extracting_EntryBytesWritten:
                ...
                case ZipProgressEventType.Extracting_AfterExtractEntry:
                ....
            }
        }
