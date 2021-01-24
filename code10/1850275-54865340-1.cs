cs
[Table("Reports", "Reporting")]
class Report
{
    [Key]
    public int Id { get; set; } 
    public virtual ICollection<Entry> Entries { get; set; }
}
abstract class Entry
{
   [Key]
   public int Id {  get; set; }
   public virtual ICollection<Report> Reports { get; set; }
}
[Table("InvoiceEntries", "Reporting")]
class InvoiceEntry : Entry
{
    public ICollection<Invoice> Invoices { get; set; }
}
class PaymentEntry
{
   [ForeignKey("Payment")]
   public int PaymentId { get;set; }
   public virtual Payment Payment { get; set; }
}
It turns out the issue there is that the report object needs to have that PaymentEntry sub typed mapped using the fluent API and the cascade turned off in order to prevent multiple cascade paths.
If all child types only have the InvoiceEntry style many to many mapping EF can figure it out by itself.
To avoid this either fluent script the other relationship to avoid the cascade problem or make all child types in to many to many relationships.
