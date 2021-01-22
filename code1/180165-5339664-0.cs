    void SheetSelectionChangeHandle(object Sheet, Range Target)
    {
       if ((Worksheet)Sheet.Names.Count != oldNamedRangeCount)
       {
          oldNamedRangeCount = (Worksheet)Sheet.Names.Count;
          // Do stuff related to NamedRangeCountChanged
       }
    }
