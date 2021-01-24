    EmployeeView.ItemAppearing += async (object sender, ItemVisibilityEventArgs e) =>
                {
                   if (EmployeeView.IsScrolling) {
                        await DisplayAlert("ItemAppearing", e.Item + " row is appearing", "OK");
                        Console.WriteLine("ItemAppearing!!!!!!!!!!");
                        //Add the ShowChopped(); and ShowFull(); 
                    }
                };
