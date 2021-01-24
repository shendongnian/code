            public static void something()
            {
                File.ReadLines(filePath)
                    .AsParallel()
                    .Select(x => x.TrimStart('[').TrimEnd(']'))
                    .Select(JsonConvert.DeserializeObject<LiveAMData>)
                    .ForAll(WriteRecord);
            }
