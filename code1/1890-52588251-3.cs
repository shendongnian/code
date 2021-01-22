     public static T GetEnum<T>(string model)
        {
            var newModel = GetStringForEnum(model);
            if (!Enum.IsDefined(typeof(T), newModel))
            {
                return (T)Enum.Parse(typeof(T), "None", true);
            }
            return (T)Enum.Parse(typeof(T), newModel.Result, true);
        }
        private static Task<string> GetStringForEnum(string model)
        {
            return Task.Run(() =>
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                var nonAlphanumericData = rgx.Matches(model);
                if (nonAlphanumericData.Count < 1)
                {
                    return model;
                }
                foreach (var item in nonAlphanumericData)
                {
                    model = model.Replace((string)item, "");
                }
                return model;
            });
        }
