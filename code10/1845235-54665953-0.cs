    public abstract class SharedLogicClass<TValue, TType>
      where TType : BaseModel<TValue>, new
    {
        public override ExecutionResult GetExecutionResult(Variant model)
        {
          var executionResult = new ExecutionResult();
          executionResult.Name = model.Name;
          var type1Result = new List<TTYpe>();
          try
          {
            for (int counter = 0; counter < model.Subvariants.Count - 1; counter++) 
            {
              var left = model.Subvariants.Count[counter];
              var right = model.Subvariants.Count[counter + 1];
              using (var t = CreateTypeManager(model))
              {
                for (int i = 0; i < 2; i++)
                {
                  if (i == 0)
                  {
                    t.Start(i);
                    if (counter == 0)
                    {
                      type1Result.Add(new TType()
                      {
                        Name = left.Name,
                        Value = t.LeftValue
                      });
                    }
                  }
                  else
                  {
                    t.Start(i);
                    var type = new TType()
                    {
                      Name = right.Name,
                      Value = t.RightValue,
                      Coordinates = t.Left + t.Right,
                      OverAllPercentage = t.OverAllPercentage,
                    });
                    AssignAdditionalValues(type, t);
                    type1Result.Add(type);
                  }
                }
              }
            }
            AssignExecutionResult(executionResult, type1Result);
          }
          catch (Exception ex)
          {
            executionResult.Success = false;
            executionResult.ErrorMessage = ex.Message;
          }
          return executionResult;
        }
        protected abstract BaseManager CreateTypeManager(Variant model);
        protected virtual void AssignAdditionalData(Type1Model type, TypeManager t) {}
        protected abstract void AssignExecutionResultList(ExecutionResult res, IList<TType> lst);
    }
    public class SharedLogicImplementationType1 : SharedLogicClass<int, Type1Model>
    {
      protected override BaseManager CreateTypeManager(Variant model)
      {
        return new Type1Manager(model);
      }
      protected override void AssignAdditionalData(Type1Model type, TypeManager t)
      {
        type.PerformanceCounter = (t.NetPlus + t.AverageRatio);
        type.MiscPercentage = t.MiscPercentage;
      }
      protected override void AssignExecutionResultList(ExecutionResult res, IList<Type1Model> lst)
      {
        res.Types1 = lst;
      }
    }
    public class SharedLogicImplementationType2 : SharedLogicClass<decimal, Type2Model>
    {
      protected override BaseManager CreateTypeManager(Variant model)
      {
        return new Type2Manager(model);
      }
      protected override void AssignExecutionResultList(ExecutionResult res, IList<Type2Model> lst)
      {
        res.Types2 = lst;
      }
    }
