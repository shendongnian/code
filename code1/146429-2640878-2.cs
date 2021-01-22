    using dto = RivWorks.DTO;
    using contracts = RivWorks.Interfaces.DataContracts;
    ...
    public static List<contracts.IProduct> Get(Guid companyID) {
        List<dto.Product> prodList = new List<dto.Product>();
        ...
        return new List<contracts.IProduct>(prodList.ToArray());
    }
