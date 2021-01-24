    for (int i = _list.Count - 1; i >= 0; i--)
    {
        if (_list[i].age == personToRemove.age && _list[i].grade == personToRemove.grade)
        {
            _list.RemoveAt(i);
            break;
        }
    }
