    var id = viewModel.MeetingCenter.MeetingCenterId;
    var items = await _meetingCenterReposiotry.GetItemsAsync();
    var item = items.FirstOrDefault(a=>a.MeetingCenterId==id);
    // User item now 
    // May be do somethig like : viewModel.MeetingCenter = item;
