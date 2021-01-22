    class MyMedia
    {
        public MyMedia(Media m)
        {
            this.Media = m;
            this.MediaUrl = App.Resource["MediaPath"] + m.Id + "." + m.Ext;
        }
        public Media Media
        {
            get; set;
        }
        public string MediaUrl
        {
            get; set;
        }
    }
