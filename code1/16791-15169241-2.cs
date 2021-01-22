    ((INotifyPropertyChanged)col).PropertyChanged += (s, e) =>
            {
                var argsEx = (PropertyChangedEventArgsEx)e;
                Trace.WriteLine(argsEx.Sender.ToString());
            };
