    foos.SingleOrDefault(f => f.EntryDate.Year == bar.EntryDate.Year &&
                              f.EntryDate.Month == bar.EntryDate.Month &&
                              f.EntryDate.Day == bar.EntryDate.Day &&
                              f.EntryDate.Hour == bar.EntryDate.Hour &&
                              f.EntryDate.Minute == bar.EntryDate.Minute &&
                              f.EntryDate.Second == bar.EntryDate.Second);
