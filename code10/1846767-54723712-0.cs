                var results = channels.Where(x => x.ChannelType != null)
                    .Select(x => new { index = int.Parse(x.ChannelName.Replace("v", "")), channel = x })
                    .GroupBy(x => x.channel.ChannelType)
                    .Select(x => x.OrderByDescending(y => y.index))
                    .Select(x => x.FirstOrDefault().channel)
                    .ToList();
