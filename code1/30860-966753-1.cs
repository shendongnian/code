    [RunWithMyTestClassCommand]
    public class AdditionSpecification
    {
      static int result;
    
      public void Because()
      {
        result = 2 + 2;
      }
    
      public void Result_is_non_zero()
      {
        Assert.True(result <> 0);
      }
    
      public void Result_is_correct()
      {
        Assert.Equal(4, result);
      }
    }
