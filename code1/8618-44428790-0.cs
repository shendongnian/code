            StreamWriter sw = null;
            var queue = new ConcurrentQueue<string>();
            var flushTask = new System.Timers.Timer(50);
            flushTask.Elapsed += (s, e) =>
            {
                while (!queue.IsEmpty)
                {
                    string line = null;
                    if (queue.TryDequeue(out line))
                        sw.WriteLine(line);
                }
                sw.FlushAsync();
            };
            flushTask.Start();
            using (var process = new Process())
            {
                try
                {
                    process.StartInfo.FileName = @"...";
                    process.StartInfo.Arguments = $"...";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.Start();
                    var outputRead = Task.Run(() =>
                    {
                        while (!process.StandardOutput.EndOfStream)
                        {
                            queue.Enqueue(process.StandardOutput.ReadLine());
                        }
                    });
                    var errorRead = Task.Run(() =>
                    {
                        while (!process.StandardError.EndOfStream)
                        {
                            queue.Enqueue(process.StandardError.ReadLine());
                        }
                    });
                    var timeout = new TimeSpan(hours: 0, minutes: 10, seconds: 0);
                    if (Task.WaitAll(new[] { outputRead, errorRead }, timeout) &&
                        process.WaitForExit((int)timeout.TotalMilliseconds))
                    {
                        if (process.ExitCode != 0)
                        {
                            throw new Exception($"Failed run... blah blah");
                        }
                    }
                    else
                    {
                        throw new Exception($"process timed out after waiting {timeout}");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Failed to succesfully run the process.....", e);
                }
            }
        }
