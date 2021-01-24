            using (HttpContent content = response.Content)
            {
                Task<string> result = content.ReadAsStringAsync();
                res = result.Result;
                var VideosList = Videos.VideosItems.FromJson(res);
                VideosListView.ItemsSource = VideosList;
            }
