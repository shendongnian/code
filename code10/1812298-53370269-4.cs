            Task.Run(async () =>  //<--here async
            {
                //Simulate async work
                Task.Run( async () => {
                    await Task.Run( () => {} ); //<--- await
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                });
                //Update property
                Title = Title + " - Done";
                StateHasChanged();
            });
