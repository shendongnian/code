    public class MyPageModel : PageModel
    {
        private readonly IReadData _readData ;
    
        public MyPageModel(IReadData readData)
        {
            _readData = readData;
        }
    
        public async Task OnGetAsync()
        {
            var userName = User.FindFirst(ClaimTypes.Name).Value; // will give the user's userName
           var Prayer = await _readData.FetchCars(userName);
        }
    }
