     public interface ITransactable
     {
         string Description { get; }
         DateTime? TransactionDate { get; }
     }
     public class CompletedTransaction : ITransactable
     {
         ...
     }
     // note conversion to extension method
     public static void FillInMissingDates<T>( this IEnumerable<T> collection, 
                                               string match,
                                               DateTime defaultDate )
            where T : ITransactable
     {
          foreach (var trans in collection.Where( t => t.Description = match ))
          {
              if (!trans.TransactionDate.HasValue)
              {
                  trans.TransactionDate = defaultDate;
              }
          }
     }
