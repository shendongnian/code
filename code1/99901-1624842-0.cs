    public static List<Type> GetAll(DateTime? startTime, DateTime? goTime)
        {
            List<Type> getResultBetween =
                (from i in DB.TableName
                 where (startTime.HasValue && i.StartTime >= startTime)
                       || (goTime.HasValue && i.GoTime >= goTime)
                 select i).ToList();
            return getResultBetween;
        }
