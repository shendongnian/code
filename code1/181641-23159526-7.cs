            dgPrimaryGrid.AutoGeneratingColumn += dgPrimaryGrid_AutoGeneratingColumn;
           
            var data = new object[] 
            {
                new Test() { Name = "Joe", UserID = "1" }
            };
            dgPrimaryGrid.ItemsSource = data;
