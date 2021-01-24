    namespace Core
    {
        public class MyViewModel : BaseViewModel
        {
            #region Public Properties
            /// <summary>
            /// The Parent object
            /// </summary>
            public Parent Parent { get; set; }
        
            public int NumberOfIndividualEngagements
            {
                get => Parent.NumberOfIndividualEngagements;
                set
                {
                    Parent.NumberOfIndividualEngagements = value;
                    OnPropertyChanged(nameof(NumberOfIndividualEngagements));
                    OnPropertyChanged(nameof(TotalAudienceReached));
                }
            }
                     
            public int NumberOfGroupEngagements
            {
                get => Parent.NumberOfGroupEngagements;
                set
                {
                    Parent.NumberOfGroupEngagements = value;
                    OnPropertyChanged(nameof(NumberOfGroupEngagements));
                    OnPropertyChanged(nameof(TotalAudienceReached));
                }
            }
  
            // Other properties...
  
            public MyViewModel()
            {
                // Load it...
            }
        }
    }
