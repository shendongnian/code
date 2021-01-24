    public async void textRotation()
        {
            for(int a =0; a < words.Length; a++)
            {
                Text.Text = words.Substring(0,a);
                Text.ScrollToHorizontalOffset(Text.Text.Last());
                await Task.Delay(500);
                
            }
        }
