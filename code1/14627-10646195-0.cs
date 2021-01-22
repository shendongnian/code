    private void RemoveNotPermittedItems(ActionDictionary menu)
    {
        foreach(var _checked in (from m in menu
                                 select new
                                 {
                                     gip = !GetIsPermitted(m.Value.Call),
                                     recur = m.Value is ActionDictionary,
                                     item = m
                                 }).ToArray())
        {
            ActionDictionary tmp = _checked.item.Value as ActionDictionary;
            if (_checked.recur)
            {
                RemoveNotPermittedItems(tmp);
            }
            if (_checked.gip || (tmp != null && tmp.Count == 0) {
                menu.Remove(_checked.item.Key);
            }
        }
    }
