    ==============The following occurred 2 times
    System.InvalidOperationException: DataTable internal index is corrupted: '13'.
       at System.Data.RBTree`1.GetNodeByIndex(Int32 userIndex)
       at System.Data.DataView.GetRow(Int32 index)
       at System.Data.DataView.GetDataRowViewFromRange(Range range)
       at System.Data.DataView.FindRowsByKey(Object[] key)
       at GenerateSomeDataTableErrors.<>c__DisplayClass9.<Main>b__8(Int32 i, ParallelLoopState s) in Program.cs:line 110
    ==============The following occurred 3 times
    System.IndexOutOfRangeException: Index 1 is either negative or above rows count.
       at System.Data.DataView.GetRow(Int32 index)
       at System.Data.DataView.GetDataRowViewFromRange(Range range)
       at System.Data.DataView.FindRowsByKey(Object[] key)
       at GenerateSomeDataTableErrors.<>c__DisplayClass9.<Main>b__8(Int32 i, ParallelLoopState s) in line 110
    ==============The following occurred 1 times
    System.NullReferenceException: Object reference not set to an instance of an object.
       at System.Data.DataView.GetRow(Int32 index)
       at System.Data.DataView.GetDataRowViewFromRange(Range range)
       at System.Data.DataView.FindRowsByKey(Object[] key)
       at GenerateSomeDataTableErrors.<>c__DisplayClass9.<Main>b__8(Int32 i, ParallelLoopState s) in Program.cs:line 110
    Press any key to continue . . .
