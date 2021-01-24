            string tab = "\t";
            string note = "Confidential";
            string dt = DateTime.Today.Date.ToString("d");
            int pg = 0;
            // Set footers
            foreach (Word.Section wordSection in doc.Sections)
            {
                pg += 1;
                Word.Range footerRange = wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                footerRange.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
                footerRange.Paragraphs.TabStops.Add(wordApp.InchesToPoints(3.25F), Word.WdTabAlignment.wdAlignTabCenter);
                footerRange.Paragraphs.TabStops.Add(wordApp.InchesToPoints(6.5F), Word.WdTabAlignment.wdAlignTabRight);
                string footerString = $"pg. {pg.ToString()}{tab}{note}{tab}{dt}";
                footerRange.Text = footerString;
            }
