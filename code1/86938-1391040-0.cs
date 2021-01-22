    class JobSlot
    {
        public JobSlot (DateTime start, int hours) { ... }
        // ...
        public DateTime End { get { return Start + Hours; } } // not the correct way to add a time, but you get the picture
        public string SlotName { get { return Start.ToString () + "-" + End.ToString  (); } }
        public string ToString () { return SlotName (); }
    }
    LoadComboBoxWithSlots (int hours)
    {
        List < JobSlot > slots;
        for ( DateTime start = FirstStartTime; start <= LastEndTime - hours; start += SlotStartTimeOffset )
            slots.Add (new JobSlot (start, hours));
        selectSlotComboBox.DataSource = slots;
        selectSlotComboBox.DisplayMember = "SlotName";
        selectSlotComboBox.Bindings.Add ("SelectedItem", bindingSource, "Slot")
    }
