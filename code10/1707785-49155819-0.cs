    internal sealed class UserInfo {
        string Code { get; set; }
        string UserName { get; set; }
    }
    string sqlQuery =
        "SELECT ReservationPackages.Code, ReservationPackages.UserName "
    +   "FROM ReservationPackages" ;
    var queryResult = DB.Database.SqlQuery<UserInfo>(sqlQuery);
    var query = queryResult.Select(info => new reportReservationReport {
        Code = info.Code
    ,   UserName = info.UserName
    });
