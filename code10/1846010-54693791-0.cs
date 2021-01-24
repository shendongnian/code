            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    SingleToneClass.Instance.DoWwork();
                    await Task.Delay(TimeSpan.FromSeconds(10));
                }
            });
