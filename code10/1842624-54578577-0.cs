    abstract class Gender : 
       whatever interfaces you need for serialization and so on
    {
      private Gender() { } // prevent subclassing 
      private class MaleGender : Gender 
      {
        // Serialization code for male gender
      }
      public static readonly Gender Male = new MaleGender();
      // now do it all again for FemaleGender
    }
