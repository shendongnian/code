    public interface Excludable
      bool? IsExcluded { get; set; }
    }
    pulic class AreaFilterValue : FilterValue, Excludable  {
       // implementation here +  type: "Area",   taxonomy?: LocationTaxonomy,
    }
