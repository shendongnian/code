            var newItem = new Reminder
            {
                Name = name,
                Date = date,
                Time = time
            };
            newItem.PropertyChanged += (o, ex) =>
            {
                if (ex.PropertyName == "Time" && newItem.Time == specificTime)
                {
                    //do what you need to do
                }
            };
            reminderList.Add( newItem );
