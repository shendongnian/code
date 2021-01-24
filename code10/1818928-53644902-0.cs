    public class ProfileDto
    {
      public static ProfileDto CreateFromDb(int id, string nickname)
      {
        // this is a constuctor.
         return new ProfileDto(id,nickname);
      }
    }
