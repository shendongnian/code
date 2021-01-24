    public interface IMyAwesomeInterface
    {
       decimal Percentage { get; set; }
       int Grade { get; set; }
       string Description { get; set; }
       decimal GPA { get; set; }
       int  Rank { get; set; }
    }
    
    public void SomeMethod<T>(Entity entity, int classId)
       where T : IMyAwesomeInterface
    {
       var collection = await ResultQuery(entity, classId).Cast<T>().ToListAsync();
       foreach (var result in collection)
       {
          decimal Percentile = 0;
          int Rank = 0;
          if (result.Percentage == Percentile)
             result.Rank = Rank;
          else
          {
             result.Rank = Rank + 1;
             Percentile = result.Percentage;
             Rank++;
          }
          var Values = await GetGrades(result.Percentage); //returns student GPA, Grade, etc.
          result.Grade = Values.Grade;
          result.Description = Values.Description;
          result.GPA = Values.GPA;
          Values = null;
          entity.Entry(result).State = EntityState.Modified;
       }
    }
