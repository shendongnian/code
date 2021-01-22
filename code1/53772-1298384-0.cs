    var query = from t in GetFreshContext().Employee select t;
    var dsQuery = (DataServiceQuery<Employee>)query;
    dsQuery.BeginExecute(result =>
    {
        ComboEmployees.ItemsSource = dsQuery.EndExecute(result).ToArray();
    }, null);
    ComboEmployees.DisplayMemberPath = "FullName";
