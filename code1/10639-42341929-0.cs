    public interface IPerson {
      int GetAge();
      string GetName();
    }
    public interface IGetPerson {
      IPerson GetPerson();
    }
    public static class IGetPersonAdditions {
      public static int GetAgeViaPerson(this IGetPerson getPerson) { // I prefer to have the "ViaPerson" in the name in case the object has another Age property.
        IPerson person = getPerson.GetPersion();
        return person.GetAge();
      }
      public static string GetNameViaPerson(this IGetPerson getPerson) {
        return getPerson.GetPerson().GetName();
      }
    }
    public class Person: IPerson, IGetPerson {
      private int Age {get;set;}
      private string Name {get;set;}
      public IPerson GetPerson() {
        return this;
      }
      public int GetAge() {  return Age; }
      public string GetName() { return Name; }
    }
