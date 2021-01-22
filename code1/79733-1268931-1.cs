    string[] names = (from n in (type.GetEvents(
        BindingFlags.Public | BindingFlags.Instance).Select(
            e => e.GetCustomAttributes(
                typeof(EventPublication), true).First() as EventPublication))
        select n.EventName).Distinct().ToArray();
