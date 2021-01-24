     public static DateTime TestDate
                {
                    get => CrossSettings.Current.GetValueOrDefault("T", DateTime.MinValue).ToLocalTime();
                    set => CrossSettings.Current.AddOrUpdateValue("T", value);
                }
