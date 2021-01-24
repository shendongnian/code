        if (tab.CustomTab)
        {
            bool showTab = true;
            if (getTabsForCase) //insert this here, no need to run if getTabsForCase.
                foreach (TabStop ts in style.ParagraphFormat.TabStops)
                {
                    if (Math.Abs(ts.Position - tab.Position) < 0.001 &&
                        ts.Alignment == tab.Alignment)
                    {
                        showTab = false;
                        break;
                    }
                }
            if (showTab || getTabsForCase)
            {
                Tabulator t = new Tabulator
                {
                    Tabulatorausrichtung = 
                        tab.Alignment == WdTabAlignment.wdAlignTabLeft
                            ? TabulatorAusrichtung.Links 
                            : TabulatorAusrichtung.Rechts,
                    Tabulatorart = TabulatorArt.Tabulator,
                    Position = tab.Position
                };
                tabList.Add(t);
            }
        }
