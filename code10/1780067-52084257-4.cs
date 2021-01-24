    class StringClipTextData : ClipTextData
    {
        public string ClipObjectData
        {
            get { return base.GetClipObjectData<string>(); }
            set { base.SetClipObjectData(value); }
        }
    }
