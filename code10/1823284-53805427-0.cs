    public static PrimitivePropertyConfiguration IsDefaultSort(this PrimitivePropertyConfiguration property)
    {
      property.HasColumnAnnotation(OrderConstants.OrderProperty, OrderConstants.Ascending);
      return property;
    }
