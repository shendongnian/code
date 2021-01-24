    public static GetEnum<T>(string model)
        {
                var newModel = GetStringForEnum(model);
                if (!Enum.IsDefined(typeof(T), newModel.Result))
                {
                    var test1 = (int)Enum.Parse(typeof(T), "None", true);
                    return test1;
                }
                var test = (int)Enum.Parse(typeof(T), newModel.Result, true);
                return test;
        }
        private static GetStringForEnum(string model)
        {
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                var nonAlphanumericData = rgx.Matches(model);
                if (nonAlphanumericData.Count < 0)
                {
                    return model;
                }
                foreach (var item in nonAlphanumericData)
                {
                    model = model.Replace((string)item, "");
                }
                return model;
        }
