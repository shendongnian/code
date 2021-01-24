    public bool UpdateStepAssignedToLevelAsync(Step step, int levelId)
            {
                using(var context = new StackOverFlowDbContext())
                {
                    var item = context.StepLevels
                                      .Include(sl => sl.Step)
                                      .FirstOrDefault(x => x.Id == step.Id && x.Id == levelId);
                    if (item == null)
                    {
                        return false;
                    }
    
                    // Updating Name property
                    item.Step.Name = step.Name;
    
                    // Other properties can be upadated
    
                    var rows = context.SaveChanges();
                    return rows > 0;
                }
                
            }
