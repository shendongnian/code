from t in db.Users
join t0 in db.User_x_Territory on new { UserID = t.Id } equals new { UserID = t0.UserID } into t0_join
from t0 in t0_join.DefaultIfEmpty()
group new {t, t0} by new {
  t.Id,
  Column1 = t.Id,
  t.FirstName,
  t.LastName,
  t0.UserID
} into g
where   g.Count() == 0
select new {
  Id = g.Key.Id,
  Expr1 = g.Key.Id,
  g.Key.FirstName,
  g.Key.LastName,
  UserID = g.Key.UserID
}
