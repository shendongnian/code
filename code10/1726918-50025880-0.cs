     Paragraph paragraph52 = new Paragraph() { RsidParagraphAddition = "00736172", RsidRunAdditionDefault = "00736172", ParagraphId = "359EF518", TextId = "77777777" };
    
                ParagraphProperties paragraphProperties52 = new ParagraphProperties();
    
                Run run28 = new Run();
                Text text26 = new Text() { Space = SpaceProcessingModeValues.Preserve };
    
                if (oversight.Lead == null)
                {
                    text26.Text = "";
                }
                else
                {
                    text26.Text = "Joe Blow - Manager";
                }
    
                run28.Append(text26);
    
                Run run29 = new Run();
                TabChar tabChar1 = new TabChar();
                run29.Append(tabChar1);
    
                Tabs tabs2 = new Tabs();
                TabStop tabStop2 = new TabStop() { Val = TabStopValues.Left, Position = 5025 };
                tabs2.Append(tabStop2);
                paragraphProperties52.Append(tabs2);
    
                Run run30 = new Run();
    
                Text text27 = new Text(); 
    
                if (oversight.Lead == null)
                {
                    text27.Text = "";
                }
                else
                {
                    text27.Text = " ______________________________";
                }
    
                run30.Append(text27);
    
                paragraph52.Append(paragraphProperties52);
                paragraph52.Append(run28);
                paragraph52.Append(run29);
                paragraph52.Append(run30);
