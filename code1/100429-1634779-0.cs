    var button = new Button {Text = "Run"};
    button.Click +=
        (sender, e) =>
            {
                var fetchTitle = new Func<string, string>(
                    address =>
                        {
                            var html = new WebClient().DownloadString(address);
                            var match = Regex.Match(html, "<title>(.*)</title>");
                            return match.Groups[1].Value;
                        });
                var displayTitle = new Action<string>(
                    title => MessageBox.Show(title));
                fetchTitle.BeginInvoke(
                    "http://stackoverflow.com",
                    result =>
                        {
                            var title = fetchTitle.EndInvoke(result);
                            if (button.InvokeRequired)
                            {
                                button.Invoke(displayTitle, title);
                            }
                            else
                            {
                                displayTitle(title);
                            }
                        },
                    null);
            };
    new Form {Controls = {button}}.ShowDialog();
