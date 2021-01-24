csharp
using Xunit;
using Bogus;
namespace SO54660453.Tests
{
   class ClassWithPrivateSetter
   {
      public string Name { get; private set; }
   }
   public class Tests
   {
      [Fact]
      public void TestClassWithPrivateSetter()
      {
         var faker = new Faker<ClassWithPrivateSetter>()
            .RuleFor(o => o.Name, f => f.Person.FullName);
         var testPoco = faker.Generate();
         Assert.False(string.IsNullOrEmpty(testPoco.Name));
      }
   }
}
