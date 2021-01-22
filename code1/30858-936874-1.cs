    public class AdditionSpecification : IUseFixture<AdditionFixture>
    {
      int result;
     
      public void SetFixture(AdditionFixture Fixture)
      {
       result = Fixture.Because();
      }
      [Fact]
      public void Result_is_non_zero()
      {
       Assert.True(result <> 0);
      }
      [Fact]
      public void Result_is_correct()
      {
       Assert.Equal(4, result);
      }
    }
