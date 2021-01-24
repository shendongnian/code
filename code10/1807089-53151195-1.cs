    private async Task Loading(Func<string> SearchStringForUser)
    {
        var user = await Task.Run(() =>
        {
            var query = database.Database.SqlQuery<VW_Users>("select * From VW_Users where 1 = 1 And GymID = " + PublicVar.ID + " " + SearchStringForUser());
            return query.ToList();
        });
        DataGrid_User.ItemsSource = user;
    }
