        public String TwitterGetPublicTimeline()
        {
            var t = new Yedda.Twitter();
            return t.GetPublicTimelineAsXML().InnerXml;
        }
