    public static class Selectors
    {
        public static readonly Expression<Func<MeetingRoomCulture, MeetingRoomCultureListViewModel>>
        MeetingRoomCultureToListViewModel = source => new MeetingRoomCultureListViewModel
        {
            Id = source.BaseEntityId,
            CancellationDuration = source.BaseEntity.CancellationDuration,
            // the rest ...
        };
        private static readonly Func<MeetingRoomCulture, MeetingRoomCultureListViewModel>
        MeetingRoomCultureToListViewModelFunc = MeetingRoomCultureToListViewModel.Compile();
        public static MeetingRoomCultureListViewModel ToMeetingRoomCultureListViewModel(
            this MeetingRoomCulture source) => MeetingRoomCultureToListViewModelFunc(source);
    }
