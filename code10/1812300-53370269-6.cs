            Task.Run(() =>
            {
                //Simulate work
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
                //Update property
                Title = Title + " - Done";
                StateHasChanged();
            });
