        private bool ContainsCanceled(List<HistoryEntry> list)
        {
            list.Sort();
            int index = list.FindLastIndex(delegate(HistoryEntry h) { return h.HistoryType == HistoryType.Cleared; });
            for (int i = index >= 0? index : 0; i < list.Count; i++)
            {
                if (list[i].HistoryType == HistoryType.Cancelled)
                {
                    return true;
                }
            }
            return list.Exists(delegate(HistoryEntry h) { return h.HistoryType == HistoryType.Cancelled; });
        }
