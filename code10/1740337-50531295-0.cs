    public void RedIndicatorColorToYellowIndicatorColor()
                {
                    StatusColor.Fill = GreenBrush;
                    DispatcherTimer ColorTimer = new DispatcherTimer();
                    ColorTimer.Interval = TimeSpan.FromSeconds(7);
                    ColorTimer.Tick += async (Sender, args) =>
                    {
                        await StatusColor.Fade(duration: 1000, delay: 0, value: 0).StartAsync();
                        StatusColor.Fill = RedBrush;
                        await StatusColor.Fade(duration: 1200, delay: 0, value: 1).StartAsync();
        
                        YellowindIcatorColorToGreenIndicatorColor();
                        ColorTimer.Stop();
                    };
                    ColorTimer.Start();
                }
        
                public void YellowindIcatorColorToGreenIndicatorColor()
                {
                    DispatcherTimer ColorTimer2 = new DispatcherTimer();
                    ColorTimer2.Interval = TimeSpan.FromSeconds(7);
                    ColorTimer2.Tick += async (Zender, Args) =>
                    {
                        await StatusColor.Fade(duration: 1000, delay: 0, value: 0).StartAsync();
                        StatusColor.Fill = YellowBrush;
                        await StatusColor.Fade(duration: 1200, delay: 0, value: 1).StartAsync();
        
                        red2green();
                        ColorTimer2.Stop();
                    };
                    ColorTimer2.Start();
                }
