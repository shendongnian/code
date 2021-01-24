            /// <summary>
            /// private method that manages the thread for the automatic update.
            /// </summary>
            private void updateLabelsContentThread()
            {
                while(true)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    Dispatcher.Invoke(new Action(() => { updateLabelsContent(); }));
                }
            }
