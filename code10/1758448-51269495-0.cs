    foreach (Section section in document.Sections)
                {
                    //Get the header range and add the header details.
                    var headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    headerRange.Font.ColorIndex = WdColorIndex.wdBlack;
                    headerRange.Font.Size = 12;
                    headerRange.Font.Name = "Arial";
                    headerRange.Font.Bold = 1;
                    headerRange.Text =  ClientNameBox.Text;
                    headerRange.InsertParagraphAfter();
                    object oCollapseEnd = WdCollapseDirection.wdCollapseEnd;
                    headerRange.Collapse(ref oCollapseEnd);
                    headerRange.Text = ClientsAddressBox.Text;
                    headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                }
