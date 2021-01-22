        public void testNamedRangeFind()
        {
            m_workbook = Globals.ThisAddIn.Application.ActiveWorkbook;
            int i = m_workbook.Names.Count;
            string address = &amp;quot;&amp;quot;;
            string sheetName = &amp;quot;&amp;quot;;
            if (i != 0)
            {
                foreach (Excel.Name name in m_workbook.Names)
                {
                    string value = name.Value;
                    //Sheet and Cell e.g. =Sheet1!$A$1 or =#REF!#REF! if refers to nothing
                    string linkName = name.Name;
                    //gives the name of the link e.g. sales
                    if (value != &amp;quot;=#REF!#REF!&amp;quot;)
                    {
                        address = name.RefersToRange.Cells.get_Address(true, true, Excel.XlReferenceStyle.xlA1, missing, missing);
                        sheetName = name.RefersToRange.Cells.Worksheet.Name;
                    }
                    Debug.WriteLine(&amp;quot;&amp;quot; + value + &amp;quot;, &amp;quot; + linkName + &amp;quot; ,&amp;quot; + address + &amp;quot;, &amp;quot; + sheetName);
                }
            }
        }
