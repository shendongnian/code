    Func<bool, Action<Result>> printItem = print =>
                    {
                        return data => {
                            if(print)
                            {
                                Console.WriteLine(data.Text);
                            }
                        };
                    };
        
    var printItemFunction = printItem(true);
        
    source.Do(item => printItemFunction(item))
          .Do(item => printItemFunction = printItem(item.Flag))
          .Subscribe();
