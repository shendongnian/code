            List<CountryList> countrylists = new List<CountryList>();
            //I am using static list items. Just change this to get data from entity framework;
            countrylists.Add(new CountryList  //pass one default list Item here so that your list is never null.
            {
                Id = 0,
                name = "Select Country"
            });
            countrylists.Add(new CountryList
            {
                Id = 1,
                name = "UK"
            });
            var viewModel = new CountryListViewModel
            {
                //Default = new DefaultModel(),
                CountryList=countrylists,
                CountryLists="Country List"
            };
            return View(viewModel);`
