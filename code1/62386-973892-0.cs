    public List<InvoiceDetailLineType> GetAllForCategory(InvoicingCategory category)
    {
        ObjectQuery<InvoiceDetailLineType> lineTypeQuery = ContextHelper.Entities.InvoiceDetailLineType.Include("CalculationRule").Include("InvoicingCategory");
        return lineTypeQuery.Where(t => t.InvoicingCategory.IdInvoicingCategory == category.IdInvoicingCategory).ToList();
    }
