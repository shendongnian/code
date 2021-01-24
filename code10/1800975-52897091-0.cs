        private void AddStyles()
        {
            stylesPart = workBookPart.AddNewPart<WorkbookStylesPart>();
            Fonts fonts = new Fonts(
                new Font(),
                new Font(new Bold())
                );
            Fills fills = new Fills(new Fill());
            Borders borders = new Borders(new Border());
            CellFormats cellFormats = new CellFormats(
                    new CellFormat(), // default
                    new CellFormat { FontId = 0, FillId = 0, BorderId = 0 }, // body
                    new CellFormat { FontId = 1, FillId = 0, BorderId = 0 } // header
                );
            stylesPart.Stylesheet = new Stylesheet(fonts, fills, borders, cellFormats);
            stylesPart.Stylesheet.Save();
        }
