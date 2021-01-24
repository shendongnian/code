     public interface IInvoiceSpecificationQueryBuilder
     {
         IQueryable<Invoice> BuildQuery(InvoiceSpecification specification, IQueryable<Creditor> query)
     }
     
     public class InvoiceSpecificationQueryBuilder : IInvoiceSpecificationQueryBuilder
     {
         public IQueryable<Invoice> BuildQuery(InvoiceSpecification specification, IQueryable<Creditor> query)
         {
            // method logic here
         }
     }
