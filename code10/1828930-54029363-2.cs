    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Users = new List<User>();
            for (int i = 0; i < 6; i++)
            {
                Users.Add(new User
                {
                    ID = i,
                    Name = $"John the {i + 1}",
                    State = i % 2 == 0 ? "CA" : "IL",
                    Cases = new List<Case>() { new Case { CaseID = (i + 1) * 10, Vendor = ((i + 1) * 10) - 2 }, new Case { CaseID = (i + 1) * 10, Vendor = ((i + 1) * 10) - 2 } }
                });
            }
        }
    }  
