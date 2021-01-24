       public int  FeedBackID { get; set; }
       public string FoodName{ get; set; }
       public List<StepModel> Steps { get; set; }
       
       public FeedBackListViewModel()
       {
          Steps = new List<StepModel>(); 
       }
    }
