            var keysIO = Observable.FromEventPattern<KeyEventArgs>(this, "KeyDown")
                                        .Select(arg => arg.EventArgs.Key)
                                        .Buffer(10, 1)
                                        .Select(keys => Enumerable.SequenceEqual(keys, _konamiArray))
                                        .Where(result => result)
                                        .Subscribe(i =>
                                                        {
                                                            Debug.WriteLine("Found Konami");
                                                        });
