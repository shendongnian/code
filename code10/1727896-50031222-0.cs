       private string _target;
       public string Target {  get { return _target; } 
                               set { 
                                     _target = value; 
                                     Targets = Regex.Matches(_target, @"(\d+)")
                                                    .OfType<Match>()
    	                                            .Select(mt => int.Parse(mt.Value))
                                                    .ToList();
       public List<int> Targets { get; set; }
