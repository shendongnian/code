                    pBar.Dispatcher.Invoke(() =>
                {
                    if (GetFileSize(source) <= 0)
                        pBar.IsIndeterminate = true;
                    else
                    {
                        pBar.IsIndeterminate = false;
                        pBar.Maximum = GetFileSize(source);
                        pBar.Value = 0;
                    }
                });
                // code...
                pBar.Dispatcher.Invoke(() =>
                {
                    pBar.Value = pBar.Value + readCount;
                });
