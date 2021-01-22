    Task[] tsk =
    {
        Task<List<double>>.Factory.StartNew(() => GetDoubleListing(inputList1, inputList2)),
        Task<List<double>>.Factory.StartNew(() => GetAnotherListing(inputList3, inputList2));
    };
