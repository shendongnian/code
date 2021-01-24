    public class FeedBackListViewModel
    {      
        public int FeedBackID { get; set; }
        public string FoodName{ get; set; }
        public List<StepModel> Steps { get; set; } = new List<StepModel>();
    
    }
