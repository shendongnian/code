    public string SelectedSubject
        {
            get { return _selectedSubject; }
            set {
                _selectedSubject = value;
                Selectedchanged();
                NotifyOfPropertyChange(() => SelectedSubject);
            }
        }
    public void Selectedchanged()
        {
            switch(SelectedSubject)
            {
                case "User Information":
                    ActiveSubject = new UserInformationViewModel();
                    break;
                case "Dealer Locations":
                    ActiveSubject = new HelpLocationViewModel();
                    break;
                case "Schedule Information":
                    ActiveSubject = new HelpScheduleViewModel();
                    break;
                case "Write Off Information":
                    ActiveSubject = new HelpWriteOffViewModel();
                    break;
                case "Loading Schedules":
                    ActiveSubject = new HelpLoadingScheduleViewModel();
                    break;
                case "Working with Repair Orders":
                    ActiveSubject = new HelpRepairOrdersViewModel();
                    break;
                case "Working with Write Offs":
                    ActiveSubject = new HelpWorkingWithWriteOffViewModel();
                    break;
                case "Generating Reports":
                    ActiveSubject = new HelpGeneratingReportsViewModel();
                    break;
                case "Working with Application Data":
                    ActiveSubject = new HelpSavingDataViewModel();
                    break;
                default:
                    ActiveSubject = new PrimaryViewModel();
                    break;
            }
        }
