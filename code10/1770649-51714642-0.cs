      public IObjective MapEntityToModel(IObjectiveEntity objectiveEntity)
        {
            return new Objective
                (
                    objectiveEntity._Id,
                    objectiveEntity.Name,
                    new TaskDetails
                    (
                        objectiveEntity.Description,
                        objectiveEntity.Comments
                    ),
                    (PriorityType)Enum.Parse(typeof(PriorityType), objectiveEntity.PriorityType)
                );
        }
