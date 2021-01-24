    public class Zodiac : Person
    {
        public Zodiac()
        {
          person.DateOfBirth = DateTime.Now; // This would not work, you have not declared an object named "person", note it is commented.
          DateOfBirth = Datetime.Now;// this doesn't work. <-- Indeed, there is a typo
          DateOfBirth = DateTime.Now;// this would work, note the uppercase Time.
        }
        //Person person = new Person();
    }
