    i = 0; doc.DocumentNode.SelectNodes("//dl").Where(x => x.HasClass("Grid")).SelectNodes(".//div").ToList().ForEach(x =>
                {
                    result.Items.Add(new DownloadItem { Name = "specs-title", Index = i,    Type = DownloadItemType.Text, Value = x.SelectNodes(".//dt").FirstOrDefault().GetText() });
                    result.Items.Add(new DownloadItem { Name = "specs",       Index = i++,  Type = DownloadItemType.Text, Value = x.SelectNodes(".//dd").GetText() });
                });
