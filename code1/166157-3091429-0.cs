       public class FakeUserRepository : IUserRepository {
              public IQueryable<SelectListItem> GetRecords(int userid) {
                        // fake_table is a list
                        return (from a in fake_table select
                        new SelectListItem {
                            Value = a.ID.ToString(),
                            Text = a.Name
                        }).AsQueryable<SelectListItem>;
              }
        }
