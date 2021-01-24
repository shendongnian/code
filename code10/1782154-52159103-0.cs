        private void bindpaggination()
        {
            var myList = GetData();
            lstvwCustomerslist.ItemsSource = myList.Take(numberOfRecPerPage);
            int count = myList.Take(numberOfRecPerPage).Count();
            lblpageInformation.Content = count + " of " + myList.Count;
        }
        private ObservableCollection<FeeType_Model> GetData()
        {
            ObservableCollection<FeeType_Model> list = new ObservableCollection<FeeType_Model>();
            var dt = feesType_ViewModel.BindALLFeesTypeData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                FeeType_Model feeType_Model = new FeeType_Model();
                feeType_Model.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                feeType_Model.Type = dt.Rows[i]["type"].ToString();
                feeType_Model.Code = dt.Rows[i]["code"].ToString();
                feeType_Model.Is_active = dt.Rows[i]["is_active"].ToString();
                feeType_Model.Created_at = dt.Rows[i]["created_at"].ToString();
                feeType_Model.Description = dt.Rows[i]["description"].ToString();
                list.Add(feeType_Model);
            }
            return list;
        }
