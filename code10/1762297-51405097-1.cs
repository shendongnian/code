    public static int addNode(CalendarNode node)
    {
        if (_calendar != null)
        {
            foreach (CalendarNode item in _calendar)
            {
                if (item.Username == node.Username)
                {
                    return 1;
                }
            }
            else
            {
                 _calendar.Add(node);
            }
        }
    }
