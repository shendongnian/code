        public enum BlahType
        {
            blah1 = 1,
            blah2 = 2
        }
        string something = "blah1";
        BlahType blah = (BlahType)Enum.Parse(typeof(BlahType), something);
