                Key[] _konamiArray = { Key.Left, Key.Left, Key.Left, Key.Left, Key.Left, Key.Left, Key.Left, Key.Left, Key.Left, Key.Left };
             
            var keysIO =   Observable.FromEventPattern<KeyEventArgs>(this, "KeyDown")
                                      .Window(10,1)
                                      .Subscribe(keyBuffer =>
                                                    {
                                                        keyBuffer.Buffer(TimeSpan.FromSeconds(10), 10).Subscribe(key =>
                                                        {
                                                            int keyCounter = 0;
                                                            foreach (var k in key)
                                                            {
                                                                if (_konamiArray[keyCounter] == k.EventArgs.Key)
                                                                {
                                                                    keyCounter++;
                                                                }
                                                                else
                                                                    continue;
                                                            }
                                                            if (keyCounter == 10)
                                                                Debug.WriteLine("Found Konami");
                                                        });
                                                    });
