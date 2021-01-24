        private void Button_Click(object sender, System.EventArgs e)
        {
            Activity.RunOnUiThread(() =>
            {
                prog.Visibility = ViewStates.Visible;
            });
            Task<bool> createPickTask = Task.Run(/*async*/ () => {
                //await Task.Delay(3000);
                bool createPickResult = Utils.createPick(firstBet, myBet, game);
                if (createPickResult)
                {
                    adapter.NotifyItemChanged(pos);
                }
                else
                {
                    showErrorMessage();
                }
                Activity.RunOnUiThread(() =>
                {
                    prog.Visibility = ViewStates.Gone;
                });
                return createPickResult;
            });
        }
