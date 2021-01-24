        var macroTabs = flattenedList
            .GroupBy(x => x.IDMacroTab)
            .Select((x) => new MacroTab
            {
                IDMacroTab = x.Key,
                Tabs = x.GroupBy(t => t.IDTab)
                        .Select(tx => new Tab {
                            IDTab = tx.Key,
                            Slots = tx.Select(s => new Slot {
                               IDSlot = s.IDSlot
                         }).ToList()
                }).ToList()
            }).ToList();
