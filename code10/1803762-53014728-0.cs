    public abstract class BaseEntity - Unchanged
    public class Owner : BaseEntity
    {
        // Parent navigation    
        public Guid YearId { get; set; }
        public virtual TaxYear Year { get; set; }
    
        // Child navigation
        public virtual ICollection<EconomyUnit> Units { get; private set; }
    }
    
    public class EconomicUnit : BaseEntity
    {
        // Parent navigation    
        public Guid OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        // Child navigation
        public virtual ICollection<Report> Reports { get; private set; }
    }
    public class Report : BaseEntity
    {
        // Parent navigation    
        public Guid UnitId { get; set; }
        public virtual EconomicUnit Unit { get; set; }
        // Child navigation    
        public virtual ICollection<ReportItem> Items { get; private set; }
    }
    public class ReportItem : BaseEntity
    {
        // Parent navigation    
        public Guid ReportId { get; set; }
        public virtual Report Report { get; set; }
        // Child navigation    
        public virtual ICollection<Invoice> Invoices { get; private set; }
    }
    public class Invoice : BaseEntity
    {
        // Parent navigation    
        public Guid ReportItemId { get; set; }
        public virtual ReportItem ReportItem { get; set; }
    }
