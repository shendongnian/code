    var ans = listMessageViewModels.Where(mvm => mvm.IsSelected)
                                   .Select(mvm => new DestinationViewClass {
                                       Subject = mvm.Subject
                                   })
                                   .ToList();
