            var f = (Action<string>)
                    (x =>
                         {
                             Console.WriteLine(x);
                         }
                    );
            var execute = (Action<Action<string>>)
                          (cmd =>
                               {
                                   cmd("Hello");
                               }
                          );
            execute(f);
