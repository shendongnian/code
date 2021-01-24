    public NewMeetingContactsView ()
     {
         InitializeComponent ();
         myMeeting = new Meeting();
         myMeeting.MeetingInvites = new ObservableCollection<string>();
         this.BindingContext = myMeeting;
         listAttendees.ItemsSource = myMeeting.MeetingInvites;
     }
