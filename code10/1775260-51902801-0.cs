    ResultView result = JsonConvert.DeserializeObject<ResultView>(jsonString,
           new JsonSerializerSettings
           {
                Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
                {
                    // System.Diagnostics.Debug.WriteLine(args.ErrorContext.Error.Message);
                    args.ErrorContext.Handled = true;
                }
            }
        );
