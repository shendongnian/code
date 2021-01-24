    DateTime? dt = DateTime.Now;
     sample.dt = dt.HasValue ? dt : null;
  
     public class sample
            {
                public static DateTime? dt { get; set; }
            }
