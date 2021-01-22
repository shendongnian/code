        public static void SetBar(this BaseDataObject dataObject, int barValue)
        {
            dataObject.SetData("bar", barValue);
        }
        public static int GetBar(this BaseDataObject dataObject)
        {
            return (int)dataObject.GetData("bar");
        }
