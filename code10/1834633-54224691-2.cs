    private class TimeLapse
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration => (EndTime - StartTime).Duration();
        public static List<TimeLapse> Merge(List<TimeLapse> items)
        {
            if (items == null || items.Count < 2) return items;
            var results = new List<TimeLapse>();
            foreach (var item in items)
            {
                var overlapsWith = results.FirstOrDefault(item.OverlapsWith);
                if (overlapsWith == null) results.Add(item);
                else overlapsWith.CombineWith(item);
            }
            return results;
        }
        private bool OverlapsWith(TimeLapse other)
        {
            return other != null &&
                   other.StartTime <= EndTime &&
                   other.EndTime >= StartTime;
        }
        private void CombineWith(TimeLapse other)
        {
            if (!OverlapsWith(other)) return;
            if (other.StartTime < StartTime) StartTime = other.StartTime;
            if (other.EndTime > EndTime) EndTime = other.EndTime;
        }
    }
