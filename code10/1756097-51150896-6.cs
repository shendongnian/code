    //remembet to add nuget and => using AutoMapper;
    public class AveragesVM:MinuteAverage //inherit from your entity class retrieved from dbContextObj.MinuteAverages 
    {
         public int Id{get;set;}
         public AveragesVM:MinuteAverage(MinuteAverage minuteAverage)
         {
            var mapper= Mapper.Initialize(cfg => cfg.CreateMap<MinuteAverage,AveragesVM>());
            return  mapper.Map<AveragesVM>(minuteAverage);
         }
    }
   
