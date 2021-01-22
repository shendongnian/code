    private static IList<T> GetList(RequestForm form)
           where T: IMyInterface
        {
            // get base list
            IMyTypeRepository myTypeRepository = new MyTypeRepository(new HybridSessionBuilder());
            IList<T> myTypes = myTypeRepository.GetAll();
    
            // create results list
            IList<T> result = new List<T>();
    
            // iterate for active + used list items
            foreach (T myType in myTypes)
            {
                if (myType.Active || form.SolutionType.Contains(myType.Value))
                {
                    result.Add(myType);
                }
            }
    
            // return sorted results
            
            return result.OrderBy(o => o.DisplayOrder).ToList();
        }
