    public class Range
    {
        private bool _originalSlotsChanged = false;
        private List<Slot> _originalSlots = new List<Slot>();
        private List<Slot> _recalculatedSlots = new List<Slot>();
        public Range(Slot slot)
        {
            AddOriginalSlot(slot);
        }
        public DateTime? Start { get; set; } = null;
        public DateTime? End { get; set; } = null;
        public List<Slot> RecalculatedSlots
        {
            get
            {
                if (_originalSlotsChanged)
                    Recalculate();
                return _recalculatedSlots;
            }
        }
        public void AddOriginalSlot(Slot slot)
        {
            if (slot != null)
            {
                _originalSlots.Add(slot);
                if (Start == null || slot.Start < Start)
                    Start = slot.Start;
                if (End == null || slot.End > End)
                    End = slot.End;
                _originalSlotsChanged = true;
            }
        }
        private void Recalculate()
        {
            _recalculatedSlots.Clear();
            var pointsInRange = _originalSlots.Select(s => s.Start);
            pointsInRange = pointsInRange.Union(
                _originalSlots.Select(s => s.End)).Distinct().OrderBy(p => p);
            var arr = pointsInRange.ToArray();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Slot slot = new Slot()
                {
                    Start = arr[i],
                    End = arr[i + 1]
                };
                AddServicesToNewSlot(slot);
                _recalculatedSlots.Add(slot);
            }
        }
        private void AddServicesToNewSlot(Slot newSlot)
        {
            List<Service> services = new List<Service>();
            foreach (Slot originalSlot in _originalSlots)
            {
                if (IsNewSlotInOriginalSlot(originalSlot, newSlot))
                    services.AddRange(originalSlot.Services);
            }
            newSlot.Services = services.OrderBy(s => s.Id).ToList();
            // optionally check for distinct services here
        }
        private bool IsNewSlotInOriginalSlot(Slot originalSlot, Slot newSlot)
        {
            return originalSlot.Start <= newSlot.Start && newSlot.Start < originalSlot.End;
        }
    }
